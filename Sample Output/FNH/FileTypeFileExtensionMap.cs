using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class FileTypeFileExtensionMap : ClassMap<FileTypeFileExtension>
	{
		public FileTypeFileExtensionMap()
		{
			Table("[NTeract].[dbo].[FileTypeFileExtension]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.FileType).Column("FileTypeId");
			References(x => x.FileExtension).Column("FileExtensionId");
			Map(x => x.Id, "Id").Not.Nullable();

		}
	}
}
