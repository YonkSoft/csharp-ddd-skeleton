using System.Collections.Generic;
using System.Threading.Tasks;
using CodelyTv.Apps.Backoffice.Frontend.Criteria;
using CodelyTv.Backoffice.Courses.Application;
using CodelyTv.Backoffice.Courses.Application.SearchByCriteria;
using CodelyTv.Shared.Domain.Bus.Query;
using Microsoft.AspNetCore.Mvc;

namespace CodelyTv.Apps.Backoffice.Frontend.Controllers.Courses
{
    [ApiController]
    [Route("/api/courses")]
    public class ApiCoursesGetController : Controller
    {
        private readonly QueryBus _bus;

        public ApiCoursesGetController(QueryBus bus)
        {
            _bus = bus;
        }

        public async Task<IEnumerable<BackofficeCourseResponse>> Index([FromQuery] FiltersParam param)
        {
            var courses = await _bus.Ask<BackofficeCoursesResponse>(
                new SearchBackofficeCoursesByCriteriaQuery(param.Filters, param.OrderBy, param.Order, param.Limit,
                    param.Offset)
            );

            return courses.Courses;
        }
    }
}