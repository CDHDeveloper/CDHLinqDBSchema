using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class FileTypeMap : ClassMap<FileType>
	{
		public FileTypeMap()
		{
			Table("[NTeract].[dbo].[FileType]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Name, "Name").Length(50);
			HasMany(x => x.FileTypeFileExtensions);
			HasMany(x => x.MediaItems);
			HasMany(x => x.MediaObjectFileTypes);
			HasMany(x => x.MediaTypeFileTypes);

		}
	}
}
