using System;
using System.Collections.Generic;

namespace InitDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(string.Format("[{0}] 正在创建数据库...", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                DataContextFactory.DataContext.Database.Create();
                Console.WriteLine(string.Format("[{0}] 数据库创建成功，准备初始化数据...", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                var initializers = GetInitializers();

                initializers.ForEach(lizer => lizer.Init());


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("完成！！！");
            Console.Read();

        }

        private static List<IInitializer> GetInitializers()
        {
            var list = new List<IInitializer>();

            //// 专业线板块课件初始化
            //list.Add(new ProfessionalLineInitializer());

            //// 系统权限角色初始化
            //list.Add(new SysInitializer());

            //// 试题类型数据初始化
            //list.Add(new QuestionTypeInitializer());

            //// 考试形式数据初始化
            //list.Add(new ExamTypeInitializer());

            //// 培训计划板块数据初始化
            //list.Add(new TrainingPlanInitializer());

            //// 专业技能数据初始化
            //list.Add(new SkillInitializer());

            //list.Add(new OnLineInitalizer());

            return list;
        }
    }
}
