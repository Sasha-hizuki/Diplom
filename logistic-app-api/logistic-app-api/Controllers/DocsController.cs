using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using logistic_app_api.Data;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocsController : ControllerBase
    {
        private readonly CarsRepository _repositoryCars;
        private readonly TrailersRepository _repositoryTrailer;
        private readonly DeliveryTasksRepository _repositoryDelivery;
        private readonly UsersRepository _repositoryUser;
        private readonly IMapper _mapper;
        private IConverter _converter;

        public DocsController(IRepository<Car> repositoryCars,
                              IRepository<Trailer> repositoryTrailer, IRepository<DeliveryTask> repositoryDelivery, 
                              IMapper mapper, IConverter converter,
                              IRepository<User> repositoryUser)
        {
            _repositoryCars = (CarsRepository)repositoryCars;
            _repositoryTrailer = (TrailersRepository)repositoryTrailer;
            _repositoryDelivery = (DeliveryTasksRepository)repositoryDelivery;
            _repositoryUser = (UsersRepository)repositoryUser;
            _mapper = mapper;
            _converter = converter;
        }

        [HttpGet]
        [Route("Cars")]
        public IActionResult Сars()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Отчет по автомобилям",
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9 },
                FooterSettings = { FontName = "Arial", FontSize = 9 }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file =_converter.Convert(pdf);
            return File(file, "application/pdf");
        }

        [HttpGet]
        [Route("Trails")]
        public IActionResult Trails()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Отчет по прицепам",
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetTrails(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9 },
                FooterSettings = { FontName = "Arial", FontSize = 9 }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);
            return File(file, "application/pdf");
        }

        [HttpGet]
        [Route("Order")]
        public IActionResult Order()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Отчет по заказам",
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetOrder(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9 },
                FooterSettings = { FontName = "Arial", FontSize = 9 }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);
            return File(file, "application/pdf");
        }

        [HttpGet]
        [Route("Person")]
        public IActionResult Person()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Отчет по сотрудникам",
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetPerson(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9 },
                FooterSettings = { FontName = "Arial", FontSize = 9 }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);
            return File(file, "application/pdf");
        }

        public string GetHTMLString()
        {
            var cars = _repositoryCars.GetAll();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Отчет по автомобилям</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Марка</th>
                                        <th>Модель</th>
                                        <th>Расход топлива</th>
                                        <th>Вин номер</th>
                                        <th>Пробег</th>
                                    </tr>");
            foreach (var emp in cars)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                  </tr>", emp.Brand, emp.Model, emp.Fuel_consumption, emp.VinNumber, emp.Mileage);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }

        public string GetTrails()
        {
            var cars = _repositoryTrailer.GetAll();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Отчет по прицепам</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Марка</th>
                                        <th>Модель</th>
                                        <th>Номер</th>
                                        <th>Дата ТО</th>
                                        <th>Дата Cтраховки</th>
                                        <th>Дата зеленной карты</th>
                                    </tr>");
            foreach (var emp in cars)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                  </tr>", emp.Brand, emp.Model, emp.Number, emp.TODate.Date.ToString("dd/MM/yyyy"), emp.BlrInsuranceDate.Date.ToString("dd/MM/yyyy"), emp.GCInsuranceDate.Date.ToString("dd/MM/yyyy"));
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
        public string GetOrder()
        {
            var cars = _repositoryDelivery.GetAll();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Отчет по прицепам</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Номер контейнера</th>
                                        <th>Вес</th>
                                        <th>Тип</th>
                                        <th>Дата загрузки</th>
                                        <th>Дата разгрузки</th>
                                        <th>Адрес загрузки</th>
                                        <th>Адрес доставки</th>
                                    </tr>");
            foreach (var emp in cars)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                  </tr>", emp.ContainerNumber, emp.Weight,emp.Type, emp.StartDate.ToString("dd/MM/yyyy"), emp.FinishDate.Date.ToString("dd/MM/yyyy"), emp.From, emp.To);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }

        public string GetPerson()
        {
            var cars = _repositoryUser.GetAll();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Отчет по сотруднкам</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Фамилия Имя</th>
                                        <th>Должность</th>
                                    </tr>");
            foreach (var emp in cars)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                  </tr>", emp.FIO, emp.User_position.Name);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
    }
}
