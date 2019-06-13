using Microsoft.AspNetCore.Hosting;
using OrderApp.Services.Abstract;
using System.IO;
using System.Linq;
using XML = OrderApp.Entity.XmlEntity;
using OrderApp.Common;
using Microsoft.Extensions.Options;
using DTO = OrderApp.Entity.EntityDTO;
using System.Xml.Serialization;
using System.Threading.Tasks;
using OrderApp.Services.Abstract.Common;
using OrderApp.Common.Implementation;
using OrderApp.Common.Abstract;

namespace OrderApp.Services.Implementation
{
    public class ImportOrdersService : IImportOrdersService
	{
		private readonly IHostingEnvironment _env;
        private readonly Settings _settings;
        private readonly IOrderRepository _orderRepository;
        private readonly IBillingAddressesRepository _billingAddressesRepository;
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly IArticlesRepository _articlesRepository;

        public ImportOrdersService
            (
            IHostingEnvironment env,
            IOptions<Settings> option,
            IOrderRepository orderRepository,
            IBillingAddressesRepository billingAddressesRepository,
            IPaymentsRepository paymentsRepository,
            IArticlesRepository articlesRepository
            )
		{
			_env = env;
            _settings = option.Value;
            _orderRepository = orderRepository;
            _billingAddressesRepository = billingAddressesRepository;
            _paymentsRepository = paymentsRepository;
            _articlesRepository = articlesRepository;
        }


		public async Task<IResult> ImportOrder()
		{
            IResult result = new Result();

			string path = Path.Combine(_env.ContentRootPath, _settings.XmlFileName);						
			string xmlInputData = string.Empty;
			string xmlOutputData = string.Empty;			
			
			xmlInputData = await File.ReadAllTextAsync(path);

			XML.Orders item = Deserialize(xmlInputData);

            //save to db
            await SaveDataToDB(item);

            result.Success = true;

            return result;
		}
		
        private async Task SaveDataToDB(XML.Orders item)
        {
           
            await _orderRepository.AddAsync(new DTO.Orders()
                {
                    OxId = item.Order.Oxid,
                    OrderDatetime = item.Order.Orderdate
                });
            await _orderRepository.SaveAsync();

            await _billingAddressesRepository.AddAsync(new DTO.BillingAddresses()
                {
                    Email = item.Order.Billingaddress.Billemail,
                    Fullname = item.Order.Billingaddress.Billfname,
                    Street = item.Order.Billingaddress.Billstreet,
                    City = item.Order.Billingaddress.Billcity,
                    Zip = item.Order.Billingaddress.Billzip,
                    HomeNumber = item.Order.Billingaddress.Billstreetnr,
                    OrderOxId = item.Order.Oxid,
                    Country = item.Order.Billingaddress.Country.Geo
                });
            await _billingAddressesRepository.SaveAsync();

            await _paymentsRepository.AddAsync(new Payments()
                {
                    Amount = item.Order.Payments.Payment.Amount,
                    OrderOxId = item.Order.Oxid,
                    MethodName = item.Order.Payments.Payment.Methodname

                });
            await _paymentsRepository.SaveAsync();

            var orderArticle = item.Order.Articles.Orderarticle;

            orderArticle.Select(article =>
            _articlesRepository.AddAsync(new DTO.Articles()
                {
                    OrderOxId = item.Order.Oxid,
                    Amount = article.Amount,
                    BrutPrice = article.Brutprice,
                    Nomenclature = article.Artnum,
                    Title = article.Title
                }));

            await _articlesRepository.SaveAsync();
            
        }

		private XML.Orders Deserialize(string input) 
		{
			XmlSerializer ser = new XmlSerializer(typeof(XML.Orders));

			using (StringReader sr = new StringReader(input))
			{
				return (XML.Orders)ser.Deserialize(sr);
			}
		}

	}
}



