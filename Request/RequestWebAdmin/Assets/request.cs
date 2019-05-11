using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System.Collections.Generic;

namespace Request
{
    class HttpRequest
    {
        private static readonly string JSON_TOKEN_INPUT =
            "{ \"deviceId\": \"2535C5EB-D6ED-4ABC-956B-4ACF29938F26\", \"token\": \"680bff9eb1ba0a8d48badd598be95c5642ad2939\" }";
        private static readonly string API_URL = "https://armuseum.ml/api/";
        private static readonly string AUTHORS_URL = API_URL + "author";

        public delegate void OnComplete<T>(T x);
        public delegate IEnumerator OnCompleteYield<T>(T x);

        private List<Author> Authors { get; set; }
        private int Completed { get; set; }

        private static void SetHeaders(UnityWebRequest request)
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "680bff9eb1ba0a8d48badd598be95c5642ad2939");
            request.SetRequestHeader("UserDevice", "2535C5EB-D6ED-4ABC-956B-4ACF29938F26");
        }

        private IEnumerator DoGetRequest(string url, OnComplete<string> callback)
        {
            var request = new UnityWebRequest(url, "GET");
            request.downloadHandler = new DownloadHandlerBuffer();
            request.certificateHandler = new CustomCertificateHandler();
            SetHeaders(request);

            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log("Error While Sending: " + request.error);
            }
            else
            {
                Debug.Log("Received: " + request.downloadHandler.text);
                callback(request.downloadHandler.text);
            }
        }

        private IEnumerator DoGetRequest(string url, OnCompleteYield<string> callback)
        {
            var request = new UnityWebRequest(url, "GET");
            request.downloadHandler = new DownloadHandlerBuffer();
            request.certificateHandler = new CustomCertificateHandler();
            SetHeaders(request);

            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log("Error While Sending: " + request.error);
            }
            else
            {
                Debug.Log("Received: " + request.downloadHandler.text);
                yield return callback(request.downloadHandler.text);
            }
        }

        private void OnAuthorsCompleted(string json)
        {
            var node = JSON.Parse(json);
            Authors = Deserializers.DeserializeAuthorList(node);
            ++Completed;
        }
    }
}