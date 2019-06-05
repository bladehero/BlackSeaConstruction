using AutoMapper;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Messages;
using BlackSeaConstruction.DataAccessLayer.Dao;
using BlackSeaConstruction.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
                });
                cfg.CreateMap<MessageVM, Message>().ForMember("DateCreated", o =>
                {
                    o.MapFrom("ReceivedAt");
                });
            }).CreateMapper();

            _messages = new MessageDao(connection);
        }

        public IEnumerable<MessageVM> GetAllMessages()
        {
            var messages = _messages.FindAll(true).OrderBy(x => x.DateModified);
            var messageVMs = Map<IEnumerable<Message>, IEnumerable<MessageVM>>(messages);
            return messageVMs;
        }

        public bool MergeMessage(MessageVM messageVM)
        {
            var message = Map<MessageVM, Message>(messageVM);
            return _messages.Merge(message);
        }

        public bool DeleteMessage(int id) => _messages.Delete(id);
    }
}
