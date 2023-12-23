﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Spotify.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Repository.Mapping.Transacao
{
    public class TransacaoMapping : IEntityTypeConfiguration<Domain.Transacao.Agreggates.Transacao>
    {
        public void Configure(EntityTypeBuilder<Domain.Transacao.Agreggates.Transacao> builder)
        {
            builder.ToTable(nameof(Domain.Transacao.Agreggates.Transacao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DtTransacao).IsRequired();
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);

            builder.OwnsOne<Merchant>(d => d.Merchant, c =>
            {
                c.Property(x => x.Nome).HasColumnName("MerchantNome").IsRequired();
            });

        }
    }
}
