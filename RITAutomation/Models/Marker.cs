using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using RITAutomation.Services;
using RITAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RITAutomation.Models
{
    public class Marker : GMarkerGoogle
    {
        public int id;
        public IReceiver receiver;
        public MarkerModeEnum mode = MarkerModeEnum.manual;

        public Marker(int id, SourceTypeEnum sourceType, string source, PointLatLng p, GMarkerGoogleType type) : base(p, type)
        {
            this.id = id;
            this.receiver = CreateReceiver(sourceType, source);
        }

        public Marker(int id, SourceTypeEnum sourceType, string source, PointLatLng p, Bitmap Bitmap) : base(p, Bitmap)
        {
            this.id = id;
            this.receiver = CreateReceiver(sourceType, source);
        }

        protected Marker(int id, SourceTypeEnum sourceType, string source, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.id = id;
            this.receiver = CreateReceiver(sourceType, source);
        }

        private IReceiver CreateReceiver(SourceTypeEnum sourceType, string source)
        {
            IReceiver receiver = null;
            switch (sourceType)
            {
                case SourceTypeEnum.UDP:
                    receiver = new UdpGPSReceiver(int.Parse(source));
                    break;

                case SourceTypeEnum.COM:
                    receiver = new ComGpsReceiver(source);
                    break;

                case SourceTypeEnum.FILE:
                    receiver = new FileGpsReceiver(source);
                    break;
            }
            return receiver;
        }

        public void UpdateCoordinates(double latitude, double longitude)
        {
            Position = new PointLatLng(latitude, longitude);
        }

        public void StartReceiving()
        {
            receiver.StartReceiving();
            Task receiving = new Task(() => SyncWithReceiver());
            receiving.ContinueWith(ReceiveExceptionHadler, TaskContinuationOptions.OnlyOnFaulted);
            receiving.Start();
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
            receiver.StopReceiving();
        }

        public void StopReceiving()
        {
            receiver.StopReceiving();
        }

        public void SetMode(MarkerModeEnum mode)
        {
            this.mode = mode;
            if(mode == MarkerModeEnum.auto && !receiver.isReceiving)
            {
                StartReceiving();
            }
        }
    }
}
