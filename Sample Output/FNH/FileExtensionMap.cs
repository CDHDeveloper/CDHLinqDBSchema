using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
public class FileExtensionMap : ClassMap<FileExtension>
}
	public FileExtensionMap()
{
		Table("[NTeract].[].[FileExtension]");
		Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
		Map(x => x.Id, "Id").Not.Nullable();
		Map(x => x.Extension, "Extension").Length(10);
		HasMany(x => x.FileExtensionMediaViewers);
		HasMany(x => x.FileTypeFileExtensions);
	}
}
