﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//
//     Zmiany w tym pliku mogą spowodować niewłaściwe zachowanie i zostaną utracone
//     w przypadku ponownego wygenerowania kodu.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SessionDto", Namespace="http://tempuri.org/")]
    public partial class SessionDto : object
    {
        
        private string RoomNameField;
        
        private string Player1Field;
        
        private string Ip1Field;
        
        private string Player2Field;
        
        private string Ip2Field;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string RoomName
        {
            get
            {
                return this.RoomNameField;
            }
            set
            {
                this.RoomNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Player1
        {
            get
            {
                return this.Player1Field;
            }
            set
            {
                this.Player1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Ip1
        {
            get
            {
                return this.Ip1Field;
            }
            set
            {
                this.Ip1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Player2
        {
            get
            {
                return this.Player2Field;
            }
            set
            {
                this.Player2Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Ip2
        {
            get
            {
                return this.Ip2Field;
            }
            set
            {
                this.Ip2Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BoardDto", Namespace="http://tempuri.org/")]
    public partial class BoardDto : object
    {
        
        private int IdField;
        
        private System.Nullable<int> PieceIdField;
        
        private System.Nullable<int> ColorIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Nullable<int> PieceId
        {
            get
            {
                return this.PieceIdField;
            }
            set
            {
                this.PieceIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public System.Nullable<int> ColorId
        {
            get
            {
                return this.ColorIdField;
            }
            set
            {
                this.ColorIdField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.WebServiceSoap")]
    public interface WebServiceSoap
    {
        
        // CODEGEN: Trwa generowanie kontraktu komunikatu, ponieważ nazwa elementu GetSessionsResult z przestrzeni nazw http://tempuri.org/ nie ma atrybutu nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSessions", ReplyAction="*")]
        ServiceReference1.GetSessionsResponse GetSessions(ServiceReference1.GetSessionsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSessions", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.GetSessionsResponse> GetSessionsAsync(ServiceReference1.GetSessionsRequest request);
        
        // CODEGEN: Trwa generowanie kontraktu komunikatu, ponieważ nazwa elementu roomName z przestrzeni nazw http://tempuri.org/ nie ma atrybutu nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PostSession", ReplyAction="*")]
        ServiceReference1.PostSessionResponse PostSession(ServiceReference1.PostSessionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PostSession", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.PostSessionResponse> PostSessionAsync(ServiceReference1.PostSessionRequest request);
        
        // CODEGEN: Trwa generowanie kontraktu komunikatu, ponieważ nazwa elementu player2 z przestrzeni nazw http://tempuri.org/ nie ma atrybutu nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateSession", ReplyAction="*")]
        ServiceReference1.UpdateSessionResponse UpdateSession(ServiceReference1.UpdateSessionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateSession", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.UpdateSessionResponse> UpdateSessionAsync(ServiceReference1.UpdateSessionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteSession", ReplyAction="*")]
        bool DeleteSession(int sessionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteSession", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> DeleteSessionAsync(int sessionId);
        
        // CODEGEN: Trwa generowanie kontraktu komunikatu, ponieważ nazwa elementu GetBoardResult z przestrzeni nazw http://tempuri.org/ nie ma atrybutu nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBoard", ReplyAction="*")]
        ServiceReference1.GetBoardResponse GetBoard(ServiceReference1.GetBoardRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBoard", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.GetBoardResponse> GetBoardAsync(ServiceReference1.GetBoardRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSessionsRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetSessions", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.GetSessionsRequestBody Body;
        
        public GetSessionsRequest()
        {
        }
        
        public GetSessionsRequest(ServiceReference1.GetSessionsRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetSessionsRequestBody
    {
        
        public GetSessionsRequestBody()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSessionsResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetSessionsResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.GetSessionsResponseBody Body;
        
        public GetSessionsResponse()
        {
        }
        
        public GetSessionsResponse(ServiceReference1.GetSessionsResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetSessionsResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ServiceReference1.SessionDto[] GetSessionsResult;
        
        public GetSessionsResponseBody()
        {
        }
        
        public GetSessionsResponseBody(ServiceReference1.SessionDto[] GetSessionsResult)
        {
            this.GetSessionsResult = GetSessionsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PostSessionRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PostSession", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.PostSessionRequestBody Body;
        
        public PostSessionRequest()
        {
        }
        
        public PostSessionRequest(ServiceReference1.PostSessionRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PostSessionRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string roomName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string routerIp;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string player1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string ip1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string macAddress1;
        
        public PostSessionRequestBody()
        {
        }
        
        public PostSessionRequestBody(string roomName, string routerIp, string player1, string ip1, string macAddress1)
        {
            this.roomName = roomName;
            this.routerIp = routerIp;
            this.player1 = player1;
            this.ip1 = ip1;
            this.macAddress1 = macAddress1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PostSessionResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PostSessionResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.PostSessionResponseBody Body;
        
        public PostSessionResponse()
        {
        }
        
        public PostSessionResponse(ServiceReference1.PostSessionResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PostSessionResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool PostSessionResult;
        
        public PostSessionResponseBody()
        {
        }
        
        public PostSessionResponseBody(bool PostSessionResult)
        {
            this.PostSessionResult = PostSessionResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateSessionRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateSession", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.UpdateSessionRequestBody Body;
        
        public UpdateSessionRequest()
        {
        }
        
        public UpdateSessionRequest(ServiceReference1.UpdateSessionRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UpdateSessionRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int sessionId;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string player2;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string ip2;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string macAddres2;
        
        public UpdateSessionRequestBody()
        {
        }
        
        public UpdateSessionRequestBody(int sessionId, string player2, string ip2, string macAddres2)
        {
            this.sessionId = sessionId;
            this.player2 = player2;
            this.ip2 = ip2;
            this.macAddres2 = macAddres2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateSessionResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateSessionResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.UpdateSessionResponseBody Body;
        
        public UpdateSessionResponse()
        {
        }
        
        public UpdateSessionResponse(ServiceReference1.UpdateSessionResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UpdateSessionResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool UpdateSessionResult;
        
        public UpdateSessionResponseBody()
        {
        }
        
        public UpdateSessionResponseBody(bool UpdateSessionResult)
        {
            this.UpdateSessionResult = UpdateSessionResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBoardRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBoard", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.GetBoardRequestBody Body;
        
        public GetBoardRequest()
        {
        }
        
        public GetBoardRequest(ServiceReference1.GetBoardRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetBoardRequestBody
    {
        
        public GetBoardRequestBody()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBoardResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBoardResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.GetBoardResponseBody Body;
        
        public GetBoardResponse()
        {
        }
        
        public GetBoardResponse(ServiceReference1.GetBoardResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBoardResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ServiceReference1.BoardDto[] GetBoardResult;
        
        public GetBoardResponseBody()
        {
        }
        
        public GetBoardResponseBody(ServiceReference1.BoardDto[] GetBoardResult)
        {
            this.GetBoardResult = GetBoardResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface WebServiceSoapChannel : ServiceReference1.WebServiceSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class WebServiceSoapClient : System.ServiceModel.ClientBase<ServiceReference1.WebServiceSoap>, ServiceReference1.WebServiceSoap
    {
        
        /// <summary>
        /// Wdróż tę metodę częściową, aby skonfigurować punkt końcowy usługi.
        /// </summary>
        /// <param name="serviceEndpoint">Punkt końcowy do skonfigurowania</param>
        /// <param name="clientCredentials">Poświadczenia klienta</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WebServiceSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(WebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), WebServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceReference1.GetSessionsResponse ServiceReference1.WebServiceSoap.GetSessions(ServiceReference1.GetSessionsRequest request)
        {
            return base.Channel.GetSessions(request);
        }
        
        public ServiceReference1.SessionDto[] GetSessions()
        {
            ServiceReference1.GetSessionsRequest inValue = new ServiceReference1.GetSessionsRequest();
            inValue.Body = new ServiceReference1.GetSessionsRequestBody();
            ServiceReference1.GetSessionsResponse retVal = ((ServiceReference1.WebServiceSoap)(this)).GetSessions(inValue);
            return retVal.Body.GetSessionsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetSessionsResponse> ServiceReference1.WebServiceSoap.GetSessionsAsync(ServiceReference1.GetSessionsRequest request)
        {
            return base.Channel.GetSessionsAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.GetSessionsResponse> GetSessionsAsync()
        {
            ServiceReference1.GetSessionsRequest inValue = new ServiceReference1.GetSessionsRequest();
            inValue.Body = new ServiceReference1.GetSessionsRequestBody();
            return ((ServiceReference1.WebServiceSoap)(this)).GetSessionsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceReference1.PostSessionResponse ServiceReference1.WebServiceSoap.PostSession(ServiceReference1.PostSessionRequest request)
        {
            return base.Channel.PostSession(request);
        }
        
        public bool PostSession(string roomName, string routerIp, string player1, string ip1, string macAddress1)
        {
            ServiceReference1.PostSessionRequest inValue = new ServiceReference1.PostSessionRequest();
            inValue.Body = new ServiceReference1.PostSessionRequestBody();
            inValue.Body.roomName = roomName;
            inValue.Body.routerIp = routerIp;
            inValue.Body.player1 = player1;
            inValue.Body.ip1 = ip1;
            inValue.Body.macAddress1 = macAddress1;
            ServiceReference1.PostSessionResponse retVal = ((ServiceReference1.WebServiceSoap)(this)).PostSession(inValue);
            return retVal.Body.PostSessionResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.PostSessionResponse> ServiceReference1.WebServiceSoap.PostSessionAsync(ServiceReference1.PostSessionRequest request)
        {
            return base.Channel.PostSessionAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.PostSessionResponse> PostSessionAsync(string roomName, string routerIp, string player1, string ip1, string macAddress1)
        {
            ServiceReference1.PostSessionRequest inValue = new ServiceReference1.PostSessionRequest();
            inValue.Body = new ServiceReference1.PostSessionRequestBody();
            inValue.Body.roomName = roomName;
            inValue.Body.routerIp = routerIp;
            inValue.Body.player1 = player1;
            inValue.Body.ip1 = ip1;
            inValue.Body.macAddress1 = macAddress1;
            return ((ServiceReference1.WebServiceSoap)(this)).PostSessionAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceReference1.UpdateSessionResponse ServiceReference1.WebServiceSoap.UpdateSession(ServiceReference1.UpdateSessionRequest request)
        {
            return base.Channel.UpdateSession(request);
        }
        
        public bool UpdateSession(int sessionId, string player2, string ip2, string macAddres2)
        {
            ServiceReference1.UpdateSessionRequest inValue = new ServiceReference1.UpdateSessionRequest();
            inValue.Body = new ServiceReference1.UpdateSessionRequestBody();
            inValue.Body.sessionId = sessionId;
            inValue.Body.player2 = player2;
            inValue.Body.ip2 = ip2;
            inValue.Body.macAddres2 = macAddres2;
            ServiceReference1.UpdateSessionResponse retVal = ((ServiceReference1.WebServiceSoap)(this)).UpdateSession(inValue);
            return retVal.Body.UpdateSessionResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.UpdateSessionResponse> ServiceReference1.WebServiceSoap.UpdateSessionAsync(ServiceReference1.UpdateSessionRequest request)
        {
            return base.Channel.UpdateSessionAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.UpdateSessionResponse> UpdateSessionAsync(int sessionId, string player2, string ip2, string macAddres2)
        {
            ServiceReference1.UpdateSessionRequest inValue = new ServiceReference1.UpdateSessionRequest();
            inValue.Body = new ServiceReference1.UpdateSessionRequestBody();
            inValue.Body.sessionId = sessionId;
            inValue.Body.player2 = player2;
            inValue.Body.ip2 = ip2;
            inValue.Body.macAddres2 = macAddres2;
            return ((ServiceReference1.WebServiceSoap)(this)).UpdateSessionAsync(inValue);
        }
        
        public bool DeleteSession(int sessionId)
        {
            return base.Channel.DeleteSession(sessionId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteSessionAsync(int sessionId)
        {
            return base.Channel.DeleteSessionAsync(sessionId);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceReference1.GetBoardResponse ServiceReference1.WebServiceSoap.GetBoard(ServiceReference1.GetBoardRequest request)
        {
            return base.Channel.GetBoard(request);
        }
        
        public ServiceReference1.BoardDto[] GetBoard()
        {
            ServiceReference1.GetBoardRequest inValue = new ServiceReference1.GetBoardRequest();
            inValue.Body = new ServiceReference1.GetBoardRequestBody();
            ServiceReference1.GetBoardResponse retVal = ((ServiceReference1.WebServiceSoap)(this)).GetBoard(inValue);
            return retVal.Body.GetBoardResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetBoardResponse> ServiceReference1.WebServiceSoap.GetBoardAsync(ServiceReference1.GetBoardRequest request)
        {
            return base.Channel.GetBoardAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.GetBoardResponse> GetBoardAsync()
        {
            ServiceReference1.GetBoardRequest inValue = new ServiceReference1.GetBoardRequest();
            inValue.Body = new ServiceReference1.GetBoardRequestBody();
            return ((ServiceReference1.WebServiceSoap)(this)).GetBoardAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WebServiceSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.WebServiceSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Nie można znaleźć punktu końcowego o nazwie „{0}”.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WebServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("https://chesswebservice.azurewebsites.net/WebService.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.WebServiceSoap12))
            {
                return new System.ServiceModel.EndpointAddress("https://chesswebservice.azurewebsites.net/WebService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Nie można znaleźć punktu końcowego o nazwie „{0}”.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            WebServiceSoap,
            
            WebServiceSoap12,
        }
    }
}
