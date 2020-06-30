using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Cloud.SDK.Core.Http;
using IBM.Watson.Assistant.v1;
using IBM.Watson.Assistant.v1.Model;
using System;

namespace APP27062020.Helpers
{
    public class WatsonChatbotHelper
    {
        #region Constants
        private const string API_KEY = "apO7ADVvcDP9RaWJqzjo0Z705CuGiOYsLuSijyxBn9l2";
        private string VERSION_DATE = DateTime.Now.ToString("yyyy-mm-dd");
        private const string SERVICE_URL = "https://api.eu-gb.assistant.watson.cloud.ibm.com/instances/4e3ffeb4-d874-4369-bea0-bcac83c04b58";
        private const string WORKSPACE_ID = "f4c1ff7a-4db9-44b2-b43d-2d3eb2777aee";

        #endregion
        //public static CovidChatbotHelper _getInstance { get; set; }

        public WatsonChatbotHelper()
        {

        }

        #region Message
        public string MessageToCovid19Bot(string message)
        {
            IamAuthenticator authenticator = new IamAuthenticator(
                apikey: API_KEY);

            AssistantService service = new AssistantService(VERSION_DATE, authenticator);
            service.SetServiceUrl(SERVICE_URL);

            DetailedResponse<MessageResponse> result = service.Message(
                workspaceId: WORKSPACE_ID,
                input: new MessageInput()
                {
                    Text = message
                });

            return result.Result.Output.Text[0];

        }
        #endregion



        #region User Data
        public void DeleteUserData()
        {
            IamAuthenticator authenticator = new IamAuthenticator(
                apikey: "{apikey}");

            AssistantService service = new AssistantService("2020-04-01", authenticator);
            service.SetServiceUrl("{serviceUrl}");

            var result = service.DeleteUserData(
                customerId: "{id}"
                );

            Console.WriteLine(result.Response);
        }
        #endregion
    }
}
