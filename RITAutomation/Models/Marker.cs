using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Microsoft.Ajax.Utilities.Configuration;
using RITAutomation.Services;
using RITAutomation.Utils;
using RITAutomation.Utils.ReceiverFactory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RITAutomation.Models
{
    public class Marker : GMarkerGoogle
    {
        public int id;
        public string source;
        public MarkerModeEnum mode = MarkerModeEnum.manual;
        private IReceiver receiver;
        public SourceTypeEnum sourceType;
        public List<Polygon> inside = new List<Polygon>();

        public Marker(int id, SourceTypeEnum sourceType, string source, PointLatLng p, GMarkerGoogleType type) : base(p, type)
        {
            this.id = id;
            receiver = new ReceiverFactoryClient(sourceType, source).Create();
            this.source = source;
            this.sourceType = sourceType;
        }

        public Marker(int id, SourceTypeEnum sourceType, string source, PointLatLng p, Bitmap Bitmap) : base(p, Bitmap)
        {
            this.id = id;
            receiver = new ReceiverFactoryClient(sourceType, source).Create();
            this.source = source;
            this.sourceType = sourceType;
        }

        protected Marker(int id, SourceTypeEnum sourceType, string source, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.id = id;
            receiver = new ReceiverFactoryClient(sourceType, source).Create();
            this.source = source;
            this.sourceType = sourceType;
        }

        public void UpdateCoordinates(double latitude, double longitude)
        {
            Position = new PointLatLng(latitude, longitude);
            Events.instance.MarkerPositionChanged(this);
        }

        public void StartReceiving()
        {
            receiver.StartReceiving();
            SetMode(MarkerModeEnum.auto);
            Task.Run(() => SyncWithReceiver()).ContinueWith(ReceiveExceptionHadler, TaskContinuationOptions.OnlyOnFaulted);
        }

        private void ReceiveExceptionHadler(Task task)
        {
            MessageBox.Show(task.Exception.InnerException.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SyncWithReceiver()
        {
            while (receiver.isReceiving)
            {
                if (mode != MarkerModeEnum.auto) continue;
                if (receiver.lastData == null) continue;
                if (receiver.lastData.isEmpty) throw new Exception("Не удалось получить данные о позиции маркера"); 
                UpdateCoordinates(receiver.lastData.point.Lat, receiver.lastData.point.Lng);
            }
            StopReceiving();
        }

        public void StopReceiving()
        {
            if (receiver != null)
                receiver.StopReceiving();
            if (mode == MarkerModeEnum.auto)
                SetMode(MarkerModeEnum.manual);
        }

        public void SetMode(MarkerModeEnum mode)
        {
            this.mode = mode;
            if (receiver == null) return;
            if(mode == MarkerModeEnum.auto && !receiver.isReceiving)
            {
                StartReceiving();
            }
        }

        public void ChangeReceiverType(SourceTypeEnum type, string source)
        {
            StopReceiving();
            receiver = new ReceiverFactoryClient(type, source).Create();
            this.source = source;
            StartReceiving();
        }

        public bool IsReceiving()
        {
            if(receiver == null) return false;
            return receiver.isReceiving;
        }

        public Marker Clone(GMarkerGoogleType type)
        {
            bool isReceiving = this.IsReceiving();
            MarkerModeEnum markerMode = this.mode;
            this.StopReceiving();
            var newMarker = new Marker(this.id, this.sourceType, this.source, this.Position, type);
            newMarker.ToolTipText = this.ToolTipText;
            if (isReceiving)
            {
                newMarker.StartReceiving();
            }
            newMarker.inside = this.inside;
            newMarker.SetMode(markerMode);
            return newMarker;
        }
    }
}
