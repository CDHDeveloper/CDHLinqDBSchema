using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class EBookInfoMap : ClassMap<EBookInfo>
	{
		public EBookInfoMap()
		{
			Table("[NTeract].[dbo].[EBookInfo]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.EBook).Column("EBookId");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.AuthorId, "AuthorId");
			Map(x => x.PublisherId, "PublisherId");
			Map(x => x.LanguageId, "LanguageId");
			Map(x => x.PageCount, "PageCount");
			Map(x => x.ThumbURI, "ThumbURI");
			Map(x => x.ImageURI, "ImageURI");
			Map(x => x.Description, "Description");

		}
	}
}
