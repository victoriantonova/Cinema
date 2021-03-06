﻿using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Cinema.SL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.SL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAccountService _userService;
        private readonly ISeatsBusyService _seatsBusyService;
        private readonly ISeanceService _seanceService;

        public OrderService(IAccountService userService, ISeatsBusyService seatsBusyService, ISeanceService seanceService, IUnitOfWork _unitOfWork)
        {
            _userService = userService;
            _seatsBusyService = seatsBusyService;
            _seanceService = seanceService;
            unitOfWork = _unitOfWork;
        }
        public IEnumerable<Orders> GetSeance(int entered_idseance)
        {
            return unitOfWork.Orders.GetAll().Where(ids => ids.IdSeance.Equals(entered_idseance));
        }

        public IEnumerable<Orders> GetUserOrders(string username)
        {
            return unitOfWork.Orders.GetAll().Where(idU => idU.IdUser.Equals(username));
        }

        public IEnumerable<Orders> getOrdersUs(string username)
        {
            return unitOfWork.Orders.GetAll().Where(u => u.IdUser.Equals(username));
        }
        public IEnumerable<Orders> getOrders()
        {            
            return unitOfWork.Orders.GetAll();
        }
        public IEnumerable<Orders> getOrdersId(string iduser)
        {
            return unitOfWork.Orders.GetAll().Where(r=>r.IdUser.Equals(iduser));
        }

        public bool IsPaid(int entered_idorder)
        {
            var datas = unitOfWork.Orders.GetAll().Where(id => id.Id.Equals(entered_idorder)).FirstOrDefault();

            if (datas.Ispaid == true)
            {
                return true;
            }
            else return false;
        }

        public void UpdateOrder(int id)
        {
            var datas = unitOfWork.Orders.GetAll().Where(i => i.Id.Equals(id)).FirstOrDefault();
            datas.Ispaid = true;
            unitOfWork.Orders.Update(datas);
        }

        public void DeleteOrder(int id)
        {
            var datas = unitOfWork.Orders.GetAll().Where(i => i.Id.Equals(id)).FirstOrDefault();
            var seanceId = unitOfWork.Seances.GetAll().Where(i => i.Id.Equals(datas.IdSeance)).FirstOrDefault();

            if (DateTime.Now.Date < seanceId.DateSeance)
            {
                unitOfWork.Orders.Delete(id);
                _seanceService.SeatIncrement(datas.IdSeance);
                _seatsBusyService.UpdateSeatBusy(datas.IdSeance, datas.IdSeat, false);
            }
            else throw new Exception("Нельзя отменить бронь, сеанс прошел");

        }
        public void CreateOrder(Orders orders)
        {
            Orders order = new Orders();

            if (_seanceService.CountSeats(orders.IdSeance) != 0)
            {
                if (_seatsBusyService.IsSeatBusy(orders.IdSeance, orders.IdSeat) == false)
                {
                    order.IdUser = orders.IdUser;
                    /*
                     * if(role.....
                     * 
                    order.Ispaid = true;
                     */
                    order.IdSeance = orders.IdSeance;
                    order.IdSeat = orders.IdSeat;
                    order.Ispaid = orders.Ispaid;
                    //добавить места
                    //на одно место меньше

                    unitOfWork.Orders.Create(order);

                    _seanceService.SeatDecrement(orders.IdSeance);

                    _seatsBusyService.UpdateSeatBusy(orders.IdSeance, orders.IdSeat, true);
                }
            }
            else throw new Exception("It's Busy");
            //else
        }
        //else

    }
}
