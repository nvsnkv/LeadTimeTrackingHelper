using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TeamUtils.LeadTimeTrackingHelper.Domain.Data;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace TeamUtils.LeadTimeTrackingHelper.Migrations
{
    [DbContext(typeof(Repository.Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta7-15540")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn);

            modelBuilder.Entity("TeamUtils.LeadTimeTrackingHelper.Domain.Data.Activity", b =>
                {
                    b.Property<string>("Key");

                    b.Key("Key");
                });

            modelBuilder.Entity("TeamUtils.LeadTimeTrackingHelper.Domain.Data.Change", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActivityKey");

                    b.Property<string>("FromKey");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("ToKey");

                    b.Key("Id");
                });

            modelBuilder.Entity("TeamUtils.LeadTimeTrackingHelper.Domain.Data.State", b =>
                {
                    b.Property<string>("Key");

                    b.Key("Key");
                });

            modelBuilder.Entity("TeamUtils.LeadTimeTrackingHelper.Domain.Data.Tag", b =>
                {
                    b.Property<string>("Key");

                    b.Property<string>("ActivityKey");

                    b.Key("Key");
                });

            modelBuilder.Entity("TeamUtils.LeadTimeTrackingHelper.Domain.Data.Change", b =>
                {
                    b.Reference("TeamUtils.LeadTimeTrackingHelper.Domain.Data.Activity")
                        .InverseCollection()
                        .ForeignKey("ActivityKey");

                    b.Reference("TeamUtils.LeadTimeTrackingHelper.Domain.Data.State")
                        .InverseCollection()
                        .ForeignKey("FromKey");

                    b.Reference("TeamUtils.LeadTimeTrackingHelper.Domain.Data.State")
                        .InverseCollection()
                        .ForeignKey("ToKey");
                });

            modelBuilder.Entity("TeamUtils.LeadTimeTrackingHelper.Domain.Data.Tag", b =>
                {
                    b.Reference("TeamUtils.LeadTimeTrackingHelper.Domain.Data.Activity")
                        .InverseCollection()
                        .ForeignKey("ActivityKey");
                });
        }
    }
}
