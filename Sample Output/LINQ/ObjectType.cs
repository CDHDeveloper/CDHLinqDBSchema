using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.ObjectType")]
	class ObjectType
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false )]
		public int Id { get; set; }

		[Column(Name="Description", DBType="nvarchar(50)"  )]
		public string Description { get; set; }

	}
}
