using System;
using Leap;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Globalization;

namespace JeuLeap
{
    class SampleListener : Listener
    {
        private Object thisLock = new Object();

        // URL de l'API
        private String urlService = "http://esaip.westeurope.cloudapp.azure.com/";

        // Initialisation variable BackUp
        private DateTime BackUp = DateTime.ParseExact("01/01/01 0:00:00 PM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture);

        // Identifiants header Authorization
        private String username = "admin";
        private String password = "salvia";

        private string currentIdRequest;

        /// Permet d'initialiser les éléments de base de l'élection.
        public void initSampleListener()
        {
            // Récupère les requètes
            string result = GetRequests();
            dynamic requests = JArray.Parse(result);
            // Affiche les requètes
            for (int i = 0; i < requests.Count; i++) {
                currentIdRequest = displayRequest(requests, i);
                SafeWriteLine(currentIdRequest);
            }
            DateTime currentTime = DateTime.Now;
        }

        // Affiche une requète par son indice et retourne son id
        public string displayRequest(dynamic requests, int i)
        {
            dynamic request = requests[i];
            string idRequest = request.id;
            string requestSummary = request.summary[0].value;
            string answerContent = request.answers[0].content[0].value;
            string answerSummary = request.answers[0].summary[0].value;

            SafeWriteLine("Veuillez voter pour la requête numéro "+(i+1)+" : "+Environment.NewLine);
            SafeWriteLine("Main droite pour OUI");
            SafeWriteLine("Main gauche pour NON");
            SafeWriteLine(requestSummary+Environment.NewLine);
            SafeWriteLine(answerContent+Environment.NewLine);
            SafeWriteLine(answerSummary);

            return idRequest;
        }

        private void SafeWriteLine(String line)
        {
            lock (thisLock)
            {
                Console.WriteLine(line);
            }
        }

        public override void OnInit(Controller controller)
        {
            SafeWriteLine("Initialized\n");

        }

        public override void OnConnect(Controller controller)
        {

            controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        public override void OnDisconnect(Controller controller)
        {
            SafeWriteLine("Disconnected\n");
        }

        public override void OnExit(Controller controller)
        {
            SafeWriteLine("Exited\n");
        }

        public override void OnFrame(Controller controller)
        {
            DateTime now = DateTime.Now;
            Frame frame = controller.Frame();
            Hand hand = frame.Hands.Rightmost;
            Vector position = hand.PalmPosition;
            float timeVisible = hand.TimeVisible;
            int codeAnswer;
            if (frame.Hands.Count > 0)
            {
                Hand h = frame.Hands[0];
                // Vérifie qu'une seule main soit utilisé
                if (frame.Hands.Count>1 || frame.Fingers.Count>5 )
                {
                    SafeWriteLine("Vous devez voter avec une seule main");
                }
                // Vérifie que le niveau de certitude est supérieur à 80%
                else if (h.Confidence > 0.8)
                {
                    // Main gauche
                    if (h.IsLeft == true)
                    {
                        SafeWriteLine("Vous avez voté NON");
                        codeAnswer = 0;
                        Vote(currentIdRequest, codeAnswer);
                    }
                    // Main droite
                    if(h.IsRight == true)
                    {
                        SafeWriteLine("Vous avez voté OUI");
                        codeAnswer = 1;
                        Vote(currentIdRequest, codeAnswer);
                    }
                }
            }
            //System.Threading.Thread.Sleep(1000);
        }

        // Récupère les demandes (requète GET)
        public string GetRequests()
        {
            // Création de la requête
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlService+"api/Requests");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            // Ajout du header Authorization
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + encoded);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        // Voter pour une demande
        public string Vote(string idRequest, int codeAnswer)
        {
            string data = "{'answer' : {'code' : "+codeAnswer+"} }";
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            
            // Création de la requête
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlService+ "api/Requests/"+idRequest+"/Vote");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = "application/json";
            request.Method = "POST";

            // Ajout du header Authorization
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + encoded);

            using (Stream requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        class Sample
        {
            public static void Main()
            {
                SampleListener listener = new SampleListener();
                Controller controller = new Controller();
                controller.AddListener(listener);
                Console.WriteLine("Appuyez sur la touche échape pour quitter: \n");
                listener.initSampleListener();
                while (true) ;
            }
        }
    }
}