using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class FileExtensionMediaViewerMap : ClassMap<FileExtensionMediaViewer>
	{
		public FileExtensionMediaViewerMap()
		{
			Table("[NTeract].[].[FileExtensionMediaViewer]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.FileExtension).Column("FileExtensionId");
			References(x => x.MediaViewer).Column("MediaViewerId");
			Map(x => x.Id, "Id").Not.Nullable();

		}
	}
}
