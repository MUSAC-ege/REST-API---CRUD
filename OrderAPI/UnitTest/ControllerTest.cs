using System.Net;
using Microsoft.AspNetCore.Mvc;
using OrderAPI;
using OrderAPI.Controllers;
using OrderAPI.Models;

namespace UnitTest1
{
    public class ControllerTest
    {

        OrderContext _context;
        UsersController _userController;
        OrdersController _orderController;
        MessagesController _messageController;

        public ControllerTest()
        {
            _context = new OrderContext();
            _userController = new UsersController(_context);
            _orderController = new OrdersController(_context);
            _messageController = new MessagesController(_context);
        }

        [Fact]
        public void Test_Get_All_User()
        {
            var result = _userController.GetUsers();
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Get_All_Orders()
        {
            var result = _orderController.GetOrders();
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Get_All_Messagges()
        {
            var result = _messageController.GetMessages();
            Assert.NotNull(result);
        }

    }
}