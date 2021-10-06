using System;
using System.Net;
using System.Threading;
using Newtonsoft;
using RestSharp;
using RestSharp.Authenticators;

namespace connectRobot
{
    public class sendCommand
    {
        private string ipaddress;
        private string port;
        private string mechanism;
        string controllerLocation;
        private RestClient client;


        public sendCommand(string ip, string p, string mech)
        /*
         Description: 

             Class constructor function. Initializes ip address, port number, 
             and mechanism name [i.e. ROB_1] variables. This constructor also implements the 
             setupConnection() function, which will initialize a connection with the given
             robot controller.

        Input Arguments: 

             ip:  string format of robot controller ip adress. If local host, this will be: "127.0.0.1"
             port: string format of robot controller port number. [i.e. "80"].
             mech: string format of robot's jogging mechanism. [i.e. "ROB_1"]                       


         */
        {
            ipaddress = ip;
            port = p;
            mechanism = mech;

            setupConnection();

        }



        public void setupConnection()
        /*
         Description: 

            This function initializes the controller location - needs ipaddress and port number to work. 
            It also initializes the https client authentication
            and sends the following Http requests in the perscribed order below:
                1. RMMP Request 
                    [Request Manual Mode Priveleges]
                2. Request Mastership
                3. Login as Local User
                4. Set jogging 
                    [Sets mechanical usin for jogging - i.e. ROB_1]            

         *implements a Thread.Sleep() after each request to ensure that server is not overwhelmed

         */
        {

            controllerLocation = "https://" + ipaddress + ":" + port;

            CookieContainer _cookieJar = new CookieContainer();
            client = new RestClient(controllerLocation);
            client.CookieContainer = _cookieJar;
            client.Authenticator = new HttpBasicAuthenticator("Default User", "robotics");


            var request = new RestRequest("/users/rmmp", Method.POST);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");
            var body = @"privilege=modify";
            request.AddParameter("application/x-www-form-urlencoded;v=2.0", body, ParameterType.RequestBody);
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (s, ce, ca, p) => true;

            var response = client.Execute(request);

            //accept the RMMP request within 5 seconds of implementing code

            Thread.Sleep(5000);

            var request2 = new RestRequest("/rw/mastership/request", Method.POST);
            request2.AddHeader("Accept", "application/json");
            request2.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");
            var response2 = client.Execute(request2);

            Console.WriteLine(response2.Content + "\n");

            Thread.Sleep(1000);

            var request3 = new RestRequest("/users/register/local", Method.POST);
            request3.AddHeader("Accept", "application/hal+json;v=2.0");
            request3.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");
            request3.AddParameter("username", "Default User");
            request3.AddParameter("application", "RobAPI2-Client");
            request3.AddParameter("location", "local");
            request3.AddParameter("local-key", "12345678");


            var response3 = client.Execute(request3);

            Console.WriteLine("Here is your response: \n" + response3.Content);

            Thread.Sleep(1000);


            var request4 = new RestRequest("rw/motionsystem/" + mechanism, Method.POST);
            request4.AddHeader("Accept", "application/json");
            request4.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");


            var response4 = client.Execute(request4);

            Console.WriteLine("Here is your response: \n" + response4.Content);


        }
        public void jog(string direction)
        {  /*
             Description: 
                   This function jogs robot according to a given input...still be  
                

            Args: 

            Returns: 
             
             
             */
            //given an instruction
            //move robot in specific motion 

            if (direction == "right")
            {

                var request = new RestRequest("/rw/motionsystem/jog", Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");
                request.AddParameter("axis1", "900");
                request.AddParameter("axis2", "0");
                request.AddParameter("axis3", "0");
                request.AddParameter("axis4", "0");
                request.AddParameter("axis5", "0");
                request.AddParameter("axis6", "0");
                request.AddParameter("ccount", "0");
                request.AddParameter("inc-mode ", "None");

                var response = client.Execute(request);

                Console.WriteLine("Here is your response: \n" + response.Content);

                Thread.Sleep(500);

            }
            else if (direction == "left")
            {
                var request = new RestRequest("/rw/motionsystem/jog", Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");
                request.AddParameter("axis1", "-900");
                request.AddParameter("axis2", "0");
                request.AddParameter("axis3", "0");
                request.AddParameter("axis4", "0");
                request.AddParameter("axis5", "0");
                request.AddParameter("axis6", "0");
                request.AddParameter("ccount", "0");
                request.AddParameter("inc-mode ", "None");

                var response = client.Execute(request);

                Console.WriteLine("Here is your response: \n" + response.Content);

                Thread.Sleep(500);

            }
            else if (direction == "left")
            {
                var request = new RestRequest("/rw/motionsystem/jog", Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");
                request.AddParameter("axis1", "-900");
                request.AddParameter("axis2", "0");
                request.AddParameter("axis3", "0");
                request.AddParameter("axis4", "0");
                request.AddParameter("axis5", "0");
                request.AddParameter("axis6", "0");
                request.AddParameter("ccount", "0");
                request.AddParameter("inc-mode ", "None");

                var response = client.Execute(request);

                Console.WriteLine("Here is your response: \n" + response.Content);

                Thread.Sleep(500);

            }
            else if (direction == "left")
            {
                var request = new RestRequest("/rw/motionsystem/jog", Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");
                request.AddParameter("axis1", "-900");
                request.AddParameter("axis2", "0");
                request.AddParameter("axis3", "0");
                request.AddParameter("axis4", "0");
                request.AddParameter("axis5", "0");
                request.AddParameter("axis6", "0");
                request.AddParameter("ccount", "0");
                request.AddParameter("inc-mode ", "None");

                var response = client.Execute(request);

                Console.WriteLine("Here is your response: \n" + response.Content);

                Thread.Sleep(500);

            }
            else
            {
                Console.WriteLine("Right or Left");

            }

            



        }
    }

}
