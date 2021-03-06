using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class MediaViewerMap : ClassMap<MediaViewer>
	{
		public MediaViewerMap()
		{
			Table("[NTeract].[dbo].[MediaViewer]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Name, "Name");
			HasMany(x => x.FileExtensionMediaViewers);
			HasMany(x => x.MediaViewerUIPlatforms);

		}
	}
}
