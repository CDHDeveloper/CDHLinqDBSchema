using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class MediaViewerUIPlatformMap : ClassMap<MediaViewerUIPlatform>
	{
		public MediaViewerUIPlatformMap()
		{
			Table("[NTeract].[dbo].[MediaViewerUIPlatform]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.MediaViewer).Column("MediaViewerId");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.UIPlatformId, "UIPlatformId");

		}
	}
}
