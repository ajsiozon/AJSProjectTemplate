using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJSProjectTemplate.BL.Based;
using AJSProjectTemplate.BL.BusinessEngine;
using AJSProjectTemplate.DataTransferObject.Dto;
namespace AJSProjectTemplate
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = SaveCustomer();
            }
        }

        private IEnumerable<CustomerDto> SaveCustomer()
        {
            var dto = new CustomerDto
            {
                CustomerId = 0,
                FirstName = "John",
                LastName = "Doe"
            };
            var business = new BusinessLogicCreator<CustomerBusinessEngine, CustomerDto>();
            return business.SaveWithIEnumerableOutput(dto);
        }
        
    }
}