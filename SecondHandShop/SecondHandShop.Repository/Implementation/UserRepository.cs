﻿using Microsoft.EntityFrameworkCore;
using SecondHandShop.Domain.Identity;
using SecondHandShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondHandShop.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ApplicationUser>();
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public ApplicationUser Get(string id)
        {
            return entities
               .Include(z => z.UserShoppingCart)
               .Include("UserShoppingCart.ProductInShoppingCarts")
               .Include("UserShoppingCart.ProductInShoppingCarts.Product")
               .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(ApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(ApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(ApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
