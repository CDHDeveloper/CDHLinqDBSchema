using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.MediaViewerUIPlatform")]
	class MediaViewerUIPlatform
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="MediaViewerId", DBType="int"  )]
		public int MediaViewerId { get; set; }

		[Column(Name="UIPlatformId", DBType="int"  )]
		public int UIPlatformId { get; set; }

	}
}
