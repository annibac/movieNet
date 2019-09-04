using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.App.Interface;

namespace MoviesDatabase.App.DAO
{
    class RateDAO : IRateDAO
    {
        private DataModelContainer ctx;

        public RateDAO()
        {
            this.ctx = new DataModelContainer();
        }

        public Rate CreateRate(Rate rate)
        {
            ctx.MoviesSet.Attach(rate.Movies);
            ctx.UserSet.Attach(rate.User);
            ctx.RateSet.Add(rate);
            ctx.SaveChanges();
            return rate;
        }

        public bool DeleteRate(Rate rate)
        {
            Rate toDelete = ctx.RateSet.Where(c => c.Id == rate.Id).FirstOrDefault();
            ctx.RateSet.Remove(toDelete);
            ctx.SaveChanges();
            return true;
        }

        public List<Rate> getAllRates()
        {
            return ctx.RateSet.ToList();
        }

        public Rate GetRate(int cid)
        {
            return ctx.RateSet.Where(c => c.Id == cid).FirstOrDefault();
        }

        public Rate UpdateRate(Rate rate)
        {
            Rate toUpdate = ctx.RateSet.Where(c => c.Id == rate.Id).FirstOrDefault();
            toUpdate.Score = rate.Score;
            toUpdate.Movies = rate.Movies;
            toUpdate.Comment = rate.Comment;
            toUpdate.User = rate.User;
            if (toUpdate.Equals(rate))
            {
                Console.WriteLine("Update ok");
                ctx.SaveChanges();
                return toUpdate;
            }
            else
            {
                throw new Exception("Update rate failed");
            }
        }
    }
}
