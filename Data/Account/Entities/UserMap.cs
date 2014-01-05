using FluentNHibernate.Mapping;
using ThinkCraft.Application.Account.Entities;

namespace ThinkCraft.Data.Account.Entities
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id)
                .Column("Id")
                .GeneratedBy.GuidComb();
            Map(x => x.Email)
                .Length(320)
                .Not.Nullable();
            Map(x => x.Name)
                .Length(100)
                .Nullable();
        }
    }
}