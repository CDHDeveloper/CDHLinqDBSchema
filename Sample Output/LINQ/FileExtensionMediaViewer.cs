using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.FileExtensionMediaViewer")]
	class FileExtensionMediaViewer
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="FileExtensionId", DBType="int"  )]
		public int FileExtensionId { get; set; }

		[Column(Name="MediaViewerId", DBType="int"  )]
		public int MediaViewerId { get; set; }

	}
}
