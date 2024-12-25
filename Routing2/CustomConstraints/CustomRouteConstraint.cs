using System.Text.RegularExpressions;

namespace Routing2.CustomConstraints
{
	public class CustomRouteConstraint : IRouteConstraint
	{
		public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
		{
			if (!values.ContainsKey(routeKey))
			{
				return false;
			}

			//defining the allowed year pattern
			//regex is a class that allows you to define patterns to match text (^:start $:end)
			Regex regex = new Regex("^2022|2023|2024$");
			string? yearValue = Convert.ToString(values[routeKey]);

			// If the year matches one of the allowed years, return true
			if (regex.IsMatch(yearValue))
			{
				return true;  //its a match
			}
			return false;

		}

	}
}
