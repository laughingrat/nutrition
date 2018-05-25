using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nutrition.Models
{
    public class Patient
    {

        // general information
        [Required]
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public Enums.Status Status { get; set; }
        public DateTime DTStamp { get; set; }

        [Required]
        public string EntryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ward { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Diagnose { get; set; }
        [Required]
        public string History { get; set; }
        [Required]
        public string ClinicFeature { get; set; }


        #region Evalution
        /*
        一、初步评定：
        1	BMI＜20.5？	是	否
        2	过去的3个月有体重下降吗？	 	 
        3	过去的1周有摄食减少吗？	 	 
        4	患有严重疾病吗（如在ICU接受治疗）？	 	 
        任一答案为“是”的进入下一步。所有答案为“否”的每周复评1次。计划较大手术时制定预防性营养计划，以免营养风险出现。
        */
        public int[] EvalutionPrimary { get; set; }

        /*
         * 、疾病状态
            疾病状态	疾病严重程度评分	若“是”请打钩
            1	正常营养需要量	无（0）	
            2	髋关节骨折、慢性疾病（肝硬化*、慢性阻塞性肺病*、糖尿病、肿瘤患者、血液透析患者）	轻度（1分）	
            3	腹部大手术*、脑卒中*、重度肺炎、血液系统恶性肿瘤患者	中度（2分）	
            4	颅脑损伤*、骨髓移植、重症监护患者（APACHE ＞10）	重度（3分）	
            合     计

         */
        public int EvalutionDisease { get; set; }
        /*
         营养状态
            营养状态	营养受损程度评分	若“是”请打钩
            	正常营养状态	无（0）	
            	3个月内体重丢失＞5%，或前一周食物摄入比正常需要量低25% ~50%	轻度（1分）	
            	2个月内体重丢失＞5%，或BMI（18.5—20.5）一般情况差，或前一周食物摄入比正常需要量低50~75%。	中度（2分）	
            	1个月内体重丢失＞5%（3个月内体重丢失＞15%），或BMI＜18.5且一般情况差，或前一周食物摄入比正常需要量低75%~100%	重度（3分）	
            合    计		

             */
        public int EvalutionNutrition { get; set; }
        /*
         三、筛查结果：
            年龄≥70岁加算1分，总分≥3.0：患者有营养不良的风险，需要营养支持治疗，总分＜3.0：若患者将接受重大手术，则每周重新评估其营养状况。
            营养筛查(NRS2002)：                  分                 
             */
        public int EvalutionScore { get; set; }
        #endregion

        /*MAP>65mmHg*/
        public bool MAPLargerThan65 { get; set; }

        /*
         营养评价： 身高              cm    目前体重              kg   占理想体重%             %   BMI             
         */
        public int Height { get; set; }
        public decimal Weight { get; set; }
        public decimal WeightPercentInIdeal { get; set; }
        public decimal BMI { get; set; }

        /*
         体重变化：过去         个月减少         k g ，占通常体重的          % 
            近两周体重       增加□     无变化□      减少□         k g

         */
        public int WeightLoseMonth { get; set; }
        public decimal WeightLose { get; set; }
        public decimal WeightLosePercent { get; set; }
        public string WeightChangeInTwoWeeks { get; set; }
        public decimal WeightLoseInTwoWeeks { get; set; }


        /*
        意识（清楚 □、嗜睡 □、昏迷 □）         误吸风险（有 □、无 □）            体温（正常 □、发热 □） 
        呼吸（自主呼吸 □、机械通气 □）          皮肤弹性（好 □、差 □）            黏膜（红润 □、苍白 □）
        褥疮（无 □、有 □               cm2）    水肿（有 □、无 □）                腹水（有 □、无 □）
         */
        public string Mentality { get; set; }
        public string AspirationRisk { get; set; }
        public string Temperature { get; set; }
        public string Breath { get; set; }
        public string Skin { get; set; }
        public string Mucosa { get; set; }
        public string Bedsore { get; set; }
        public decimal BedsoreArea { get; set; }
        public string Edema { get; set; }
        public string Ascites { get; set; }

        /*
         食物过敏及不耐受：                                    食物与药物相互影响：                                 
         */
        public string Allergy { get; set; }
        public string EffectWithDrug { get; set; }

        /*
         营养摄入量：谷薯类         g 蔬果类         g肉蛋类         g奶类         g豆制品         g脂类         g
         */
        public int Grain { get; set; }
        public int Vegetable { get; set; }
        public int Meat { get; set; }
        public int Milk { get; set; }
        public int Bean { get; set; }
        public int Fat { get; set; }

        /*
         营养途径：  经口（固体 □ 、半流 □ 、液体 □）                肠内营养（鼻胃管 □ 、鼻空肠管 □、胃造口 ）
         肠外营养（外周静脉□、中心静脉□、PICC □ ）
         */
        public string ThroughMouth { get; set; }
        public string ThroughEnteral { get; set; }
        public string ThroughParenteral { get; set; }


        /*
         进食量较平时（1月前）减少：    否 □、   有（减少25% □、    50% □、    75%及以上 □）持续            周
         */
        public bool FeedReduce { get; set; }
        public decimal FeedReducePercent { get; set; }
        public int FeedReduceLastWeeks { get; set; }

        /*
         消化道症状：无 □      厌食 □      恶心呕吐（轻 □、中 □ 、重 □）      腹胀（轻 □、中 □ 、重 □ ） 
           腹泻 □         天         次/天                   胃肠功能评分               分
         */
        public bool IsDigest { get; set; }
        public bool Apocleisis { get; set; }
        public string NauseaAndVomiting { get; set; }
        public string Ventosity { get; set; }
        public bool IsDiarrhea { get; set; }
        public int DiarrheaDay { get; set; }
        public int DiarrheaFrequencyPerDay { get; set; }
        public decimal DiarrheaScore { get; set; }

        /*
         活动改变 ： 无 □ 、减退 □、能下床活动 □、卧床 □            应激反应：无 □、低度 □、中度 □、重度 □ 
         */
        public string ActivityChange { get; set; }
        public string StressResponse { get; set; }

        /*
         检验：  Hb             g/L     Ly/WBC           ×109/L  
        TP/ALb           g/L      PALB            mg/L   TBIL/DBIL           umol/L    ALT/AST          u/L
        UA             umol/L    Cr             umol/L    BUN              mmol/L  
        GLUO             mmol/L   HbA1            %         TG               mmol/L     TCHO            mmol/L
         K             mmol/L  Na/Cl            mmol/L    Ca/P             mmol/L       Mg            mmol/L

         */
        public decimal Examine_HB { get; set; }
        public decimal Examine_WBC { get; set; }
        public decimal Examine_TPALB { get; set; }
        public decimal Examine_PALB { get; set; }
        public decimal Examine_TBILDBIL { get; set; }
        public decimal Examine_ALTAST { get; set; }
        public decimal Examine_UA { get; set; }
        public decimal Examine_CR { get; set; }
        public decimal Examine_BUN { get; set; }
        public decimal Examine_GLUO { get; set; }
        public decimal Examine_HBA1 { get; set; }
        public decimal Examine_TG { get; set; }
        public decimal Examine_TCHO { get; set; }
        public decimal Examine_K { get; set; }
        public decimal Examine_NACL { get; set; }
        public decimal Examine_CAP { get; set; }
        public decimal Examine_MG { get; set; }

        /*
         营养诊断：                                                                                                  
            营养治疗方案： 每日给予目标热能            Kcal，           配制，其中蛋白质            g，热氮比           ；
            脂肪            g，碳水化合物            g，膳食纤维           g，食盐            g；
                        Kcal/           ml﹒d，起始肠内营养，预计           天达目标量。
           

            热氮比 = [热能 - （蛋白质克数 * 4）] / (蛋白质克数 * 6.25)  保留 1 位小数

         */

        public string NutritionDiagnosis { get; set; }
        public int TreatCalorie { get; set; }
        public string TreatConfiguration { get; set; }
        public int TreatProtein { get; set; }
        public int TreatThermalNitrogenRatio { get; set; }
        public int TreatFat { get; set; }
        public int TreatCarbohydrates { get; set; }
        public int TreatdietaryFiber { get; set; }
        public int TreatSalt { get; set; }
        public int TreatRateKcal { get; set;  }
        public int TreatRateML { get; set; }
        public int TreatDay { get; set; }
    }
}