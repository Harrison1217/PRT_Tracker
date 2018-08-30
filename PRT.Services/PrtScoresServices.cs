using PRT.Contracts;
using PRT.Data;
using PRT.Model;
using PRTTracker.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Services
{
    public class PrtScoresServices : IPRTService
    {
        private readonly Guid _userId;
        


        public PrtScoresServices(Guid userId)
        {
            _userId = userId;
            
        }

        public bool PrtCreate(PrtScoresCreate model)
        {
            var entity =
                new PrtScores()
                {
                    UserID = _userId,
                    NumPushups = model.Push_Ups,
                    NumSitUps = model.Sit_Ups,
                    MM = model.MM,
                    SS = model.SS,         
                    RunTime = model.MM + ":" + model.SS,
                    PrtDate = model.Prt_Date,
                    RtSeconds = (model.MM * 60) + model.SS,
                    

                };




        
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Scores.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PrtScoresList> GetPrtScores()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Scores
                        .Where(e => e.UserID == _userId)
                        .Select(
                            e =>
                                new PrtScoresList
                                {
                                    prtId = e.prtID,
                                    NumPushups = e.NumPushups,
                                    NumSitups = e.NumSitUps,
                                    SS = e.SS,
                                    MM = e.MM,
                                    RunTime = e.RunTime,
                                    PrtDate = e.PrtDate,
                                    RtSeconds = e.RtSeconds
                                }
                          
                                );
                return query.ToArray();
            }
        }

        public PrtDetail GetPrtById(int prtId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Scores
                        .Single(e => e.prtID == prtId && e.UserID == _userId);
                return
                    new PrtDetail
                    {
                        PrtId = entity.prtID,
                        NumPushups = entity.NumPushups,
                        NumSitups = entity.NumSitUps,
                        MM = entity.MM,
                        SS = entity.SS,
                        RunTime = entity.RunTime,
                        PrtDate = entity.PrtDate,
                        RtSeconds = entity.RtSeconds
                    };

            }
        }

        public List<double> GetPRTChartPushUps()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = from b in context.Scores
                            where b.UserID == _userId
                            orderby b.PrtDate
                            select b.NumPushups;


                List<double> plist = query.ToList();

                return plist;

            }
        }

        public List<double> GetPRTChartSitUps()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = from b in context.Scores
                            where b.UserID == _userId
                            orderby b.PrtDate
                            select b.NumSitUps;


                List<double> plist = query.ToList();

                return plist;

            }
        }

        public List<double> GetPRTChartRunTime()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = from b in context.Scores
                            where b.UserID == _userId
                            orderby b.PrtDate
                            select b.RtSeconds;


                List<double> plist = query.ToList();

                return plist;

            }
        }

        public List<DateTime> GetPRTLabels()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = from b in context.Scores
                            where b.UserID == _userId
                            orderby b.PrtDate
                            select b.PrtDate;

                List<DateTime> elist = query.ToList();

                return elist;

            }
        }

        public List<string> FormatDateTime(List<DateTime> list)
        {
            List<string> datelabel = new List<string>();
            foreach (var item in list)
            {

                datelabel.Add(item.ToString("d"));
            }
            return datelabel;
        }
    }
}
