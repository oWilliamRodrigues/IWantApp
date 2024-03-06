﻿using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Authorization;

namespace IWantApp.Endpoints.Employees
{
    public class EmployeeGetAll
    {
        public static string Template => "/employees";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        [Authorize(Policy = "EmployeePolicy")]
        public async static Task<IResult> Action(int? page, int? rows, QueryAllUsersWithClaimName query)
        {
            var result = await query.Execute(page.Value, rows.Value);
            return Results.Ok(result);
        }
    }
}