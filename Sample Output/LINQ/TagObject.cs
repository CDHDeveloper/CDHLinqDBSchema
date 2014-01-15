using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.TagObject")]
	class TagObject
	{
		[Column(Name="Id", DBType="int"  )]
		public int Id { get; set; }

		[Column(Name="TagId", DBType="int"  )]
		public int TagId { get; set; }

		[Column(Name="ObjectId", DBType="int"  )]
		public int ObjectId { get; set; }

	}
}
