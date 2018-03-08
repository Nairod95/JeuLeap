using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moteur
{
    public class PositionMain
    {
        public string DeterminerPosition(
            float GST,
            float xPN, float yPN, float zPN)
        {
            if (GST < 0.1f && Math.Abs(xPN) < 0.3f && yPN < -0.9F && Math.Abs(zPN) < 0.3f) return "Papier";
            else if (GST < 0.1f && xPN > 0.7F && Math.Abs(yPN) < 0.3f && Math.Abs(zPN) < 0.5f) return "Ciseau";
            else if (GST > 0.9f && Math.Abs(xPN) < 0.3f && yPN < -0.9F && Math.Abs(zPN) < 0.3f) return "Pierre";
            else if (GST > 0.9f && xPN > 0.7F && Math.Abs(yPN) < 0.3f && Math.Abs(zPN) < 0.5f) return "Puits";
            else return "Aucune";
        }

        //public string DeterminerPosition(float confidence, 
        //    float xD, float yD, float zD,
        //    float xFD0, float yFD0, float zFD0, float xFD1, float yFD1, float zFD1, float xFD2, float yFD2, float zFD2, float xFD3, float yFD3, float zFD3, float xFD4, float yFD4, float zFD4,
        //    float GST, bool isLeft, bool isRight, bool isValid,
        //    float xPN, float yPN, float zPN, float pPN, float rPN, float wPN,
        //    float xPP, float yPP, float zPP, float pPP, float rPP, float wPP,
        //    float PS, 
        //    float xSC, float ySC, float zSC, float pSC, float rSC, float wSC, float SR, 
        //    float xSPP, float ySPP, float zSPP, float pSPP, float rSPP, float wSPP, 
        //    float xWP, float yWP, float zWP, float pWP, float rWP, float wWP)
        //{
        //    if (GST < 0.1f && Math.Abs(xPN) < 0.3f && yPN < -0.9F && Math.Abs(zPN) < 0.3f) return "Papier";
        //    else if (GST < 0.1f && xPN > 0.7F && Math.Abs(yPN) < 0.3f && Math.Abs(zPN) < 0.5f) return "Ciseau";
        //    else if (GST > 0.9f && Math.Abs(xPN) < 0.3f && yPN < -0.9F && Math.Abs(zPN) < 0.3f) return "Pierre";
        //    else if (GST > 0.9f && xPN > 0.7F && Math.Abs(yPN) < 0.3f && Math.Abs(zPN) < 0.5f) return "Puits";
        //    else return "Aucune";
        //}
    }
}
