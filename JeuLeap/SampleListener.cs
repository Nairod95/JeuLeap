using Leap;
using Moteur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JeuLeap
{
    class SampleListener : Listener
    {
        private Object thisLock = new Object();
        private PositionMain moteur = new PositionMain();
        private bool connected = false;

        private void SafeWriteLine(String line)
        {
            lock (thisLock)
            {
                if (connected)
                {
                    Console.Clear();
                    Console.WriteLine(line);
                    System.Threading.Thread.Sleep(10);
                }
                else
                {
                    Console.WriteLine("Le Leap Motion n'est pas détecté");
                }
            }
        }

        public override void OnConnect(Controller controller)
        {
            connected = true;
        }

        public override void OnFrame(Controller controller)
        {
            Frame frame = controller.Frame();
            StringBuilder sb = new StringBuilder();
            //if (frame.Id.ToString().EndsWith("000")) { System.Threading.Thread.Sleep(10000); }
            sb.Append("Frame id : ").Append(frame.Id);
            sb.Append(", Timestamp : ").Append(frame.Timestamp);
            sb.Append(", Hands : ").Append(frame.Hands.Count);
            sb.Append(", Fingers : ").Append(frame.Fingers.Count);
            if (frame.Hands.Count > 0)
            {
                sb.Append(Environment.NewLine).Append(Environment.NewLine);
                Hand h = frame.Hands[0];
                sb.Append("Confidence : ").Append(h.Confidence);
                sb.Append(", xD : ").Append(h.Direction.x.ToString("N3").Replace(",", "."));
                sb.Append(", yD : ").Append(h.Direction.y.ToString("N3").Replace(",", "."));
                sb.Append(", zD : ").Append(h.Direction.z.ToString("N3").Replace(",", "."));
                sb.Append(Environment.NewLine);
                sb.Append(", xFD0 : ").Append(h.Fingers[0].Direction.x.ToString("N3").Replace(",", "."));
                sb.Append(", yFD0 : ").Append(h.Fingers[0].Direction.y.ToString("N3").Replace(",", "."));
                sb.Append(", zFD0 : ").Append(h.Fingers[0].Direction.z.ToString("N3").Replace(",", "."));
                sb.Append(", xFD1 : ").Append(h.Fingers[1].Direction.x.ToString("N3").Replace(",", "."));
                sb.Append(", yFD1 : ").Append(h.Fingers[1].Direction.y.ToString("N3").Replace(",", "."));
                sb.Append(", zFD1 : ").Append(h.Fingers[1].Direction.z.ToString("N3").Replace(",", "."));
                sb.Append(", xFD2 : ").Append(h.Fingers[2].Direction.x.ToString("N3").Replace(",", "."));
                sb.Append(", yFD2 : ").Append(h.Fingers[2].Direction.y.ToString("N3").Replace(",", "."));
                sb.Append(", zFD2 : ").Append(h.Fingers[2].Direction.z.ToString("N3").Replace(",", "."));
                sb.Append(", xFD3 : ").Append(h.Fingers[3].Direction.x.ToString("N3").Replace(",", "."));
                sb.Append(", yFD3 : ").Append(h.Fingers[3].Direction.y.ToString("N3").Replace(",", "."));
                sb.Append(", zFD3 : ").Append(h.Fingers[3].Direction.z.ToString("N3").Replace(",", "."));
                sb.Append(", xFD4 : ").Append(h.Fingers[4].Direction.x.ToString("N3").Replace(",", "."));
                sb.Append(", dFD4 : ").Append(h.Fingers[4].Direction.y.ToString("N3").Replace(",", "."));
                sb.Append(", zFD4 : ").Append(h.Fingers[4].Direction.z.ToString("N3").Replace(",", "."));
                sb.Append(Environment.NewLine);
                sb.Append(", GST : ").Append(h.GrabStrength.ToString("N3").Replace(",", "."));
                sb.Append(Environment.NewLine);
                sb.Append(", left : ").Append(h.IsLeft.ToString());
                sb.Append(", right : ").Append(h.IsRight.ToString());
                sb.Append(", valid : ").Append(h.IsValid.ToString());
                sb.Append(Environment.NewLine);
                sb.Append(", xPN : ").Append(h.PalmNormal.x.ToString("N3").Replace(",", "."));
                sb.Append(", yPN : ").Append(h.PalmNormal.y.ToString("N3").Replace(",", "."));
                sb.Append(", zPN : ").Append(h.PalmNormal.z.ToString("N3").Replace(",", "."));
                sb.Append(", pPN : ").Append(h.PalmNormal.Pitch.ToString("N3").Replace(",", "."));
                sb.Append(", rPN : ").Append(h.PalmNormal.Roll.ToString("N3").Replace(",", "."));
                sb.Append(", wPN : ").Append(h.PalmNormal.Yaw.ToString("N3").Replace(",", "."));
                sb.Append(Environment.NewLine);
                sb.Append(", xPP : ").Append(h.PalmPosition.x.ToString("N3").Replace(",", "."));
                sb.Append(", yPP : ").Append(h.PalmPosition.y.ToString("N3").Replace(",", "."));
                sb.Append(", zPP : ").Append(h.PalmPosition.z.ToString("N3").Replace(",", "."));
                sb.Append(", pPP : ").Append(h.PalmPosition.Pitch.ToString("N3").Replace(",", "."));
                sb.Append(", rPP : ").Append(h.PalmPosition.Roll.ToString("N3").Replace(",", "."));
                sb.Append(", wPP : ").Append(h.PalmPosition.Yaw.ToString("N3").Replace(",", "."));
                sb.Append(Environment.NewLine);
                sb.Append(", PS : ").Append(h.PinchStrength.ToString("N3").Replace(",", "."));
                sb.Append(Environment.NewLine);
                sb.Append(", xSC : ").Append(h.SphereCenter.x.ToString("N3").Replace(",", "."));
                sb.Append(", ySC : ").Append(h.SphereCenter.y.ToString("N3").Replace(",", "."));
                sb.Append(", zSC : ").Append(h.SphereCenter.z.ToString("N3").Replace(",", "."));
                sb.Append(", pSC : ").Append(h.SphereCenter.Pitch.ToString("N3").Replace(",", "."));
                sb.Append(", rSC : ").Append(h.SphereCenter.Roll.ToString("N3").Replace(",", "."));
                sb.Append(", wSC : ").Append(h.SphereCenter.Yaw.ToString("N3").Replace(",", "."));
                sb.Append(", SR : ").Append(h.SphereRadius.ToString("N3").Replace(",", "."));
                sb.Append(Environment.NewLine);
                sb.Append(", xSPP : ").Append(h.StabilizedPalmPosition.x.ToString("N3").Replace(",", "."));
                sb.Append(", ySPP : ").Append(h.StabilizedPalmPosition.y.ToString("N3").Replace(",", "."));
                sb.Append(", zSPP : ").Append(h.StabilizedPalmPosition.z.ToString("N3").Replace(",", "."));
                sb.Append(", pSPP : ").Append(h.StabilizedPalmPosition.Pitch.ToString("N3").Replace(",", "."));
                sb.Append(", rSPP : ").Append(h.StabilizedPalmPosition.Roll.ToString("N3").Replace(",", "."));
                sb.Append(", wSPP : ").Append(h.StabilizedPalmPosition.Yaw.ToString("N3").Replace(",", "."));
                sb.Append(Environment.NewLine);
                sb.Append(", xWP : ").Append(h.WristPosition.x.ToString("N3").Replace(",", "."));
                sb.Append(", yWP : ").Append(h.WristPosition.y.ToString("N3").Replace(",", "."));
                sb.Append(", zWP : ").Append(h.WristPosition.z.ToString("N3").Replace(",", "."));
                sb.Append(", pWP : ").Append(h.WristPosition.Pitch.ToString("N3").Replace(",", "."));
                sb.Append(", rWP : ").Append(h.WristPosition.Roll.ToString("N3").Replace(",", "."));
                sb.Append(", wWP : ").Append(h.WristPosition.Yaw.ToString("N3").Replace(",", "."));
                sb.Append(Environment.NewLine).Append(Environment.NewLine);
                //sb.Append("Position déterminée POUR LA MAIN GAUCHE : " + moteur.DeterminerPosition(h.Confidence
                //    , h.Direction.x, h.Direction.y, h.Direction.z
                //    , h.Fingers[0].Direction.x, h.Fingers[0].Direction.y, h.Fingers[0].Direction.z, h.Fingers[1].Direction.x, h.Fingers[1].Direction.y, h.Fingers[1].Direction.z, h.Fingers[2].Direction.x, h.Fingers[2].Direction.y, h.Fingers[2].Direction.z, h.Fingers[3].Direction.x, h.Fingers[3].Direction.y, h.Fingers[3].Direction.z, h.Fingers[4].Direction.x, h.Fingers[4].Direction.y, h.Fingers[4].Direction.z
                //    , h.GrabStrength
                //    , h.IsLeft, h.IsRight, h.IsValid
                //    , h.PalmNormal.x, h.PalmNormal.y, h.PalmNormal.z, h.PalmNormal.Pitch, h.PalmNormal.Roll, h.PalmNormal.Yaw
                //    , h.PalmPosition.x, h.PalmPosition.y, h.PalmPosition.z, h.PalmPosition.Pitch, h.PalmPosition.Roll, h.PalmPosition.Yaw
                //    , h.PinchStrength
                //    , h.SphereCenter.x, h.SphereCenter.y, h.SphereCenter.z, h.SphereCenter.Pitch, h.SphereCenter.Roll, h.SphereCenter.Yaw
                //    , h.SphereRadius
                //    , h.StabilizedPalmPosition.x, h.StabilizedPalmPosition.y, h.StabilizedPalmPosition.z, h.StabilizedPalmPosition.Pitch, h.StabilizedPalmPosition.Roll, h.StabilizedPalmPosition.Yaw
                //    , h.WristPosition.x, h.WristPosition.y, h.WristPosition.z, h.WristPosition.Pitch, h.WristPosition.Roll, h.WristPosition.Yaw));
                //sb.Append("Position déterminée POUR LA MAIN : " + moteur.DeterminerPosition(h.GrabStrength, h.PalmNormal.x, h.PalmNormal.y, h.PalmNormal.z));
                //System.IO.File.AppendAllText(@"C:\Temp\LeapOutput.csv",
                //    h.GrabStrength.ToString("N3").Replace(",", ".") + ";"
                //    + h.PalmNormal.x.ToString("N3").Replace(",", ".") + ";"
                //    + h.PalmNormal.y.ToString("N3").Replace(",", ".") + ";"
                //    + h.PalmNormal.z.ToString("N3").Replace(",", ".") + ";"
                //    + moteur.DeterminerPosition(h.GrabStrength, h.PalmNormal.x, h.PalmNormal.y, h.PalmNormal.z) + Environment.NewLine);
            }
            SafeWriteLine(sb.ToString());
        }
    }
}
