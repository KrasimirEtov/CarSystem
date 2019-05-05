﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models.Associative;

namespace CarSystem.Services.Contracts
{
	public interface IPersonFinesService
	{
		Task<List<PersonFines>> GetAllPersonFinesAsync();
	}
}
