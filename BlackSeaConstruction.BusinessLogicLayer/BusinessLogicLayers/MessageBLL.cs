using AutoMapper;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Messages;
using BlackSeaConstruction.DataAccessLayer.Dao;
using BlackSeaConstruction.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data;

namespace BlackSeaConstruction.BusinessLogicLayer.BusinessLogicLayers
{
    public class MessageBLL : BaseBLL
    {
        MessageDao _messages;

        public MessageBLL(IDbConnection connection)
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Message, MessageVM>().ForMember("ReceivedAt", o =>
                {
                    o.MapFrom("DateCreated");
                }).AfterMap((m, vm) =>
                {
                    vm.Status = GetStatus(m.Status);
                });
                cfg.CreateMap<MessageVM, Message>().ForMember("DateCreated", o =>
                {
                    o.MapFrom("ReceivedAt");
                }).AfterMap((vm, m) =>
                {
                    m.Status = GetStatus(vm.Status);
                });
            }).CreateMapper();

            _messages = new MessageDao(connection);
        }

        public int MessagesCount(bool withDeleted = true) => _messages.Count(withDeleted);

        public MessageVM GetMessageById(int id)
        {
            var message = _messages.FindById(id);
            var messageVM = Map<Message, MessageVM>(message);
            return messageVM;
        }

        public IEnumerable<MessageVM> GetMessages(int count = 10, int skip = 0, bool withDeleted = true)
        {
            var messages = _messages.Take(count, skip, withDeleted);
            var messageVMs = Map<IEnumerable<Message>, IEnumerable<MessageVM>>(messages);
            return messageVMs;
        }

        public bool MergeMessage(MessageVM messageVM)
        {
            var message = Map<MessageVM, Message>(messageVM);
            return _messages.Merge(message);
        }

        public bool Delete(int id) => _messages.Delete(id);
        public bool RestoreMessage(int id) => _messages.Restore(id);
        public bool DeleteOrRestoreMessage(int id) => _messages.FindById(id).IsDeleted ? _messages.Restore(id) : _messages.Delete(id);

        private Status GetStatus(string status)
        {
            Status _status;
            switch (status)
            {
                case "C":
                    _status = Status.C;
                    break;
                case "R":
                    _status = Status.R;
                    break;
                default:
                    _status = Status.P;
                    break;
            }
            return _status;
        }
        private string GetStatus(Status status)
        {
            string _status;
            switch (status)
            {
                case Status.C:
                    _status = "C";
                    break;
                case Status.R:
                    _status = "R";
                    break;
                default:
                    _status = "P";
                    break;
            }
            return _status;
        }
    }
}
