using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using NLog;
using NLog.Web;
using RepositoryLayer.Entity;

namespace HelloGreetingApplication.Controllers
{
    /// <summary>
    /// class providing api for Hello Greeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private readonly ILogger<HelloGreetingController> logger;
        private readonly IGreetingBL greetingBL;

        public HelloGreetingController(ILogger<HelloGreetingController> logger, IGreetingBL greetingBL)
        {
            this.greetingBL = greetingBL;
            this.logger = logger;
        }
        /// <summary>
        /// Get method to get the greeting message
        /// </summary>
        /// <returns>"Hello, World!"</returns>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Message = "Hello API Endpoint Hit";
            responseModel.Success = true;
            responseModel.Data = "Hello, World!";
            return Ok(responseModel);
        }
        [HttpGet]
        [Route("GreetingMessage")]
        public IActionResult Get1()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            var result = greetingBL.printHelloWorldBL();
            responseModel.Message = "Success";
            responseModel.Success = true;
            responseModel.Data = result;
            return Ok(responseModel);
        }

        [HttpPost]
        [Route("UserAttributeMesssage")]
        public IActionResult UserAttributeMsg(UserModel userModel)
        {
            var message = greetingBL.UserAttributeMsgBL(userModel);
            return Ok(message);
        }

        /// <summary>
        /// Post method to get the greeting message
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>response model</returns>
        [HttpPost]
        public IActionResult Post(RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Request received successfully";
            responseModel.Data = $"Key: {requestModel.key}, Value: {requestModel.value}";
            return Ok(responseModel);
        }

        /// <summary>
        /// Put method to update the data
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="updateModel"></param>
        [HttpPut]
        public IActionResult Put([FromBody] RequestModel requestModel, [FromQuery] UpdateModel updateModel)
        {
            ResponseModel<string> response = new ResponseModel<string>();
            updateModel.NewKey = requestModel.key;
            updateModel.NewValue = requestModel.value;
            response.Success = true;
            response.Message = "Data Updated";
            response.Data = $"new key: {updateModel.NewKey}, new Value: {updateModel.NewValue}";
            return Ok(response);
        }

        /// <summary>
        /// Patch method to update the value of existing key
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="updateModel"></param>
        /// <returns></returns>
        [HttpPatch]
        public IActionResult Patch([FromBody] RequestModel requestModel, [FromQuery] UpdateModel updateModel)
        {
            ResponseModel<string> response = new ResponseModel<string>();
            if (requestModel.key == updateModel.NewKey)
            {
                updateModel.NewValue = requestModel.value;
                response.Success = true;
                response.Message = "Value updated";
                response.Data = $"new key: {updateModel.NewKey}, new Value: {updateModel.NewValue}";
                return Ok(response);
            }
            else
            {
                response.Success = false;
                response.Message = "key does not exist";
                response.Data = "";
                return NotFound(response);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] RequestModel requestModel, [FromQuery] UpdateModel updateModel)
        {
            ResponseModel<string> response = new ResponseModel<string>();

            // Check if the key exists
            if (requestModel.key == updateModel.NewKey)
            {
                // Perform deletion (set to null or remove from the data source)
                updateModel.NewKey = null;
                updateModel.NewValue = null;

                response.Success = true;
                response.Message = "Key deleted successfully";
                response.Data = $"Deleted key: {requestModel.key}";

                return Ok(response);
            }
            else
            {
                response.Success = false;
                response.Message = "Key does not exist";
                response.Data = "";

                return NotFound(response);
            }

        }

        /// <summary>
        /// method for add message
        /// </summary>
        /// <param name="greetingModel"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("MessageAdd")]
        public IActionResult AddMessage(GreetingModel greetingModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            var result = greetingBL.AddMessageBL(greetingModel);
            if (result)
            {
                responseModel.Success = true;
                responseModel.Message = "Message added.";
                responseModel.Data = greetingModel.GreetingMsg;
                return Ok(responseModel);
            }
            return BadRequest(responseModel);
        }


        [HttpPost]
        [Route("FindMessage")]
        public IActionResult FindMessage(RequestMessageId requestMessageId)
        {
            ResponseModel<string?> response = new ResponseModel<string?>();

            var result = greetingBL.FindMessageBL(requestMessageId);
            if (result != null)
            {
                response.Success = true;
                response.Message = "Message got.";
                response.Data = result.GreetingMsg;
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet]
        [Route("GetListMessage")]
        public ActionResult<List<GreetingEntity>> ListMessage()
        {
            ResponseModel<List<GreetingEntity>> responseModel = new ResponseModel<List<GreetingEntity>>();
            List<GreetingEntity> output = greetingBL.messageListBL();
            if (output != null && output.Count > 0)
            {
                responseModel.Success = true;
                responseModel.Message = "Message List";
                responseModel.Data = output;
                return Ok(responseModel);
            }
            responseModel.Success = false;
            responseModel.Message = "";
            return BadRequest(responseModel);
        }

        [HttpPatch]
        [Route("EditMessage")]
        public IActionResult GreetingMsgEdit(MsgResponseModel msgResponseModel) {
            ResponseModel<MsgResponseModel> responseModel = new ResponseModel<MsgResponseModel>();
            var output = greetingBL.GreetingMsgEditBL(msgResponseModel);
            if (output != null) {
                responseModel.Success = true;
                responseModel.Message = "Message Edited";
                responseModel.Data = output;
                return Ok(responseModel);
            }
            responseModel.Success = false;
            responseModel.Message = "";
            return BadRequest(responseModel);
        }
        [HttpDelete]
        [Route("DeleteMessage")]
        public IActionResult GreetingMsgDelete(DeleteMsgModel deleteMsgModel)
        {
            ResponseModel<DeleteMsgModel> responseModel = new ResponseModel<DeleteMsgModel>();
            var output = greetingBL.GreetingMsgDeleteBL(deleteMsgModel);
            if (output != null) { 
                responseModel.Success=true;
                responseModel.Message = "Message Deleted";
                responseModel.Data = output;
                return Ok(responseModel);
            }
            responseModel.Success = false;
            responseModel.Message = "";
            return BadRequest(responseModel);
        }
    }
}