using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.MediaTypeFileType")]
	class MediaTypeFileType
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="MediaTypeId", DBType="int"  )]
		public int MediaTypeId { get; set; }

		[Column(Name="FileTypeId", DBType="int"  )]
		public int FileTypeId { get; set; }

	}
}
