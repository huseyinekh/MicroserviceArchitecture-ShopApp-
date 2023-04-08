using AutoMapper;
using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Contact;
using FreeCourses.Services.Catalog.Dtos.Message;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Services.interfaces;
using FreeCourses.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourses.Services.Catalog.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMongoCollection<Message> _messageCollection;



        public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection =
             database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
            _messageCollection =
                 database.GetCollection<Message>(databaseSettings.MessageCollectionName);
        }

        public async Task<Response<List<MessageDto>>> GetAllMessagesAsync()

         => Response<List<MessageDto>>.Success(
                  _mapper.Map<List<MessageDto>>(
                      await _messageCollection.Find(x => true).ToListAsync()), 200);

        public async Task<Response<List<ContactDto>>> GetAllAsync()
          => Response<List<ContactDto>>.Success(
                  _mapper.Map<List<ContactDto>>(
                      await _contactCollection.Find(x => true).ToListAsync()), 200);

        public async Task<Response<NoConetent>> SendMessage(MessageDto message)
        {
            var _message = _mapper.Map<Message>(message);
            await _messageCollection.InsertOneAsync(_message);
            return Response<NoConetent>.Success(200);
        }


        public async Task<Response<NoConetent>> DeleteMessageAsync(string id)
        {
            var For = await _messageCollection.Find<Message>(x => x.Id == id).FirstOrDefaultAsync();
            if (For == null)
                return Response<NoConetent>.Fail("Message Not Found", 404);
            return Response<NoConetent>.Success(200);
        }

        public async Task<Response<NoConetent>> UpdateAsync(ContactDto data)
        {
            var updateData = _mapper.Map<Contact>(data);
            var res = await _contactCollection.FindOneAndReplaceAsync(x => x.Id == updateData.Id, updateData);
            if (res == null)
                return Response<NoConetent>.Fail("Message Not Found", 404);
            return Response<NoConetent>.Success(200);
        }

        public async Task<Response<NoConetent>> CreateAsync(ContactCreateDto data)
        {
            var contact = _mapper.Map<Contact>(data);
            await _contactCollection.InsertOneAsync(contact);
            return Response<NoConetent>
                .Success(200);
        }
    }
}
