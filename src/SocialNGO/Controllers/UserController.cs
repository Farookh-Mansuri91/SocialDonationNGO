using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialNGO.Business.Constants;
using SocialNGO.Common.Constants;
using SocialNGO.Common.Filters;
using SocialNGO.Infrastructure.Db;
using SocialNGO.Infrastructure.Db.Entities;
using SocialNGO.Models.Request;
using System.Linq.Expressions;
using System.Text.Json;

namespace SocialNGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private IUserManager _userService;
        private ApplicationDBContext _contect;

        public UserController(IConfiguration config, IUserManager userService, ApplicationDBContext contect)
        {
            _config = config;
            _userService = userService;
            _contect = contect;

        }

        [HttpGet]
        [Route("countries")]
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return (IEnumerable<Country>)Ok(await _userService.GetCountries());
            //return _context.Countries.ToList();
        }

        [HttpGet]
        [Route("states/{countryId}")]
        public async Task<IEnumerable<State>> GetAllStates(int countryId) => await _userService.GetStates(countryId);

        [HttpGet]
        [Route("cities/{stateId}")]
        public async Task <IEnumerable<City>> GetCities(int stateId)
        {
            return await _userService.GetCities(stateId);
        }

        //  [HttpGet(Name = "getUserss")]
        //public IEnumerable<User> Get([FromQuery] SearchParams searchParam)
        //{

        //    List<ColumnFilter> columnFilters = new List<ColumnFilter>();
        //    if (!String.IsNullOrEmpty(searchParam.ColumnFilters))
        //    {
        //        try
        //        {
        //            columnFilters.AddRange(JsonSerializer.Deserialize<List<ColumnFilter>>(searchParam.ColumnFilters));
        //        }
        //        catch (Exception)
        //        {
        //            columnFilters = new List<ColumnFilter>();
        //        }
        //    }

        //    List<ColumnSorting> columnSorting = new List<ColumnSorting>();
        //    if (!String.IsNullOrEmpty(searchParam.OrderBy))
        //    {
        //        try
        //        {
        //            columnSorting.AddRange(JsonSerializer.Deserialize<List<ColumnSorting>>(searchParam.OrderBy));
        //        }
        //        catch (Exception)
        //        {
        //            columnSorting = new List<ColumnSorting>();
        //        }
        //    }

        //    Expression<Func<User, bool>> filters = null;
        //    //First, we are checking our SearchTerm. If it contains information we are creating a filter.
        //    var searchTerm = "";
        //    if (!string.IsNullOrEmpty(searchParam.SearchTerm))
        //    {
        //        searchTerm = searchParam.SearchTerm.Trim().ToLower();
        //        filters = x => x.FirstName.ToLower().Contains(searchTerm);
        //    }
        //    // Then we are overwriting a filter if columnFilters has data.
        //    if (columnFilters.Count > 0)
        //    {
        //        var customFilter = CustomExpressionFilter<User>.CustomFilter(columnFilters, "users");
        //        filters = customFilter;
        //    }


        //    var query = _contect.Users.AsQueryable().CustomQuery(filters);
        //    var count=query.Count();
        //    var filteredData = query.CustomPagination(searchParam.PageNumber,searchParam.PageSize).ToList();

        //    var pagedList = new PagedList<User>(filteredData, count, searchParam.PageNumber, searchParam.PageSize);

        //    if (pagedList != null)
        //    {
        //        Response.AddPaginationHeader(pagedList.MetaData);
        //    }

        //    return pagedList;
        //}

        /// <summary>
        /// Pagination https://medium.com/@rashad_m/mastering-filtering-and-pagination-in-asp-net-core-and-react-js-part-1-591b10a65993
        /// </summary>
        /// <param name="searchParam"></param>
        /// <param name="columnfilters [{"Id","FirstName"}]"></param>
        /// <returns></returns>
        [HttpGet(Name = "getUsers")]
        public async Task<IActionResult> Get([FromQuery] SearchParams searchParam)
        {
            var pagedList = await _userService.GetUsers(searchParam);
            //var tt = pagedList.ToList();
            if (pagedList.Item1 != null)
            {
                Response.AddPaginationHeader(pagedList.Item2);
            }
            return Ok(pagedList.Item1);
        }

    }
}
