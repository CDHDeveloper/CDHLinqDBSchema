using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.FileTypeFileExtension")]
	class FileTypeFileExtension
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="FileTypeId", DBType="int"  )]
		public int FileTypeId { get; set; }

		[Column(Name="FileExtensionId", DBType="int"  )]
		public int FileExtensionId { get; set; }

	}
}
