﻿using Bookstore_Backend_C_.Data;
using Bookstore_Backend_C_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bookstore_Backend_C_.Helpers
{
    public static class DatabaseSeeder
    {
        public static async Task SeedBooks(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<BookstoreContext>();
            //var userManager = serviceProvider.GetRequiredService<UserManager<UserModel>>();

            try
            {
                if (!dbContext.Books.Any())
                {
                    await dbContext.Books.AddRangeAsync(
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "סודות בית השמפניה",
                            Author = "קריסטין הרמל",
                            Image = "https://images-evrit.yit.co.il/Images/Products/covers_2020/new_winemakers_master.jpg",
                            Summary = "סיפור קורע לב על החלטה אחת שמשנה חיים שלמים",
                            Price = 60.5,
                            Discount = 0
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "המכתב האבוד",
                            Author = "ג'יליאן קנטור",
                            Image = "https://images-evrit.yit.co.il/Images/Products/covers_2018/letter_master(1).jpg",
                            Summary = "זהו רומן היסטורי שעלילתו מתפצלת לשני קווים מקבילים, ומתפרשת מאוסטריה שלקראת מלחמת העולם השנייה ועד ללוס אנג’לס של שנות התשעים.",
                            Price = 120,
                            Discount = 50
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "מכתב שנשכח",
                            Author = "קתרין יוז",
                            Image = "https://images-evrit.yit.co.il/Images/Products/covers_2018/letter_master.jpg",
                            Summary = "טינה קרייג לא מוותרת על התנדבות שבועית בחנות הצדקה לבגדים משומשים. במנצ´סטר של שנות השבעים, זהו מקום המפלט היחיד שלה מהבית בו שוכב בעלה מעולף בסלון אחרי עוד לילה של שתייה לשוכרה. ",
                            Price = 95,
                            Discount = 0,
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "יער הכוכבים הנמוגים",
                            Author = "קריסטין הרמל",
                            Image = "https://images-evrit.yit.co.il/Images/Products/NewBO/Products/28119/forest_Master.jpg",
                            Summary = "יונה, שנולדה בשם אינגה, לא זוכרת הרבה מהוריה או מהעולם שמחוץ ליער. כשהיתה בת שנתיים, היא נגנבה מהוריה הגרמנים על ידי קשישה יהודייה בשם ירושה, שראתה את הנסתר וחשה שהיא חייבת לקחת את הילדה מחיק משפחתה אל היער.",
                            Price = 65,
                            Discount = 0,
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "צופן דה וינצ׳י",
                            Author = "דן בראון",
                            Image = "https://images-evrit.yit.co.il/Images/Products/covers_2017/_master(21).jpg",
                            Summary = "בעת ביקור בפריז מקבל רוברט לנגדון, מומחה לסמלים, טלפון בהול בשעת לילה מאוחרת. האוצֵר הזקן של הלובר נרצח במוזיאון, וצופן סתום נמצא ליד גופתו. כשלנגדון מנסה לפענח את החידות המוזרות בעזרת מפענחת הצפנים סופי נווה, נדהמים שניהם לגלות שורה של רמזים ביצירותיו של דה וינצ'י, שהוסוו בחכמה על ידי הצייר.",
                            Price = 55,
                            Discount = 0,
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "הגשרים של מחוז מדיסון",
                            Author = "רוברט ג'יימס וולר",
                            Image = "https://images-evrit.yit.co.il/Images/Products/covers_2019_b/medison_master.jpg",
                            Summary = "הגשרים של מחוז מדיסון מאת רוברט ג'יימס וולר ראה אור לראשונה ב-1992, והיה לתופעה. בתוך זמן קצר, הפך לאחד מרבי המכר הגדולים של המאה העשרים: 60 מיליון עותקים נמכרו ממנו ברחבי העולם, ב-40 שפות שונות. הספר כיכב במקום הראשון ברשימת רבי המכר של הניו-יורק טיימס, ונותר בה שלוש שנים ברציפות. והיה כמובן גם הסרט המצליח, בכיכובם של קלינט איסטווד ומריל סטריפ.",
                            Price = 50,
                            Discount = 0,
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "אורח באחוזת פארלי",
                            Author = "ריס בואן",
                            Image = "https://images-evrit.yit.co.il/Images/Products/NewBO/Products/32131/orech_beachozat_ferlie_Master.jpg",
                            Summary = "מלחמת העולם השנייה מגיעה לאחוזת פארלי, מקום מושבם של לורד וסטרהאם וחמש בנותיו, כאשר חייל עם מצנח פגום נופל אל מותו בשטחה. המדים והציוד שלו מעוררים חשד, וקצין MI5 וחבר המשפחה בן קרסוול לוקח על עצמו בחשאי את המשימה להכריע אם מדובר במרגל גרמני. המשימה גם מעניקה לו הזדמנות להימצא בקרבתה של פמלה, בתו האמצעית של לורד וסטרהאם, שבה הוא מאוהב בחשאי. אך לפמלה יש סוד משלה: היא התקבלה לעבודה בבלצ'לי פארק, מקום משכנה של היחידה הבריטית לפיצוח צפנים.",
                            Price = 76,
                            Discount = 0,
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "ספר השמות האבודים",
                            Author = "קריסטין הרמל",
                            Image = "https://images-evrit.yit.co.il/Images/Products/NewBO/Products/24415/lostNames_Master.jpg",
                            Summary = "כשאווה טראוב אברמס, ספרנית על סף פרישה, מבחינה בוקר אחד בעיתון בתמונה של ספר שלא ראתה זה יותר משישים וחמש שנים – ספר השמות האבודים – מבטה קופא. מתברר שחוקרים מצאו את הספר ומתקשים לפענח את החידה הטמונה בו – חידה שרק אווה יודעת את פתרונה.",
                            Price = 68,
                            Discount = 0,
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "דיו חיוור",
                            Author = "הרלן קובן",
                            Image = "https://images-evrit.yit.co.il/Images/Products/ebooks2/just_one_look_master.jpg",
                            Summary = "הרלן קובן, מחבר רבי-המכר עוצרי הנשימה הנעלמים וההזדמנות האחרונה, עושה זאת שוב, בספר שכבש בסערה את מצעדי המכירות בכל מקום בעולם שבו הופיע, וקיבע סופית את מעמדו של קובן כמלך הבלתי-מעורער של ספרות המתח האמריקאית. דיו חיוור הוא שם הלהיט הגדול של להקה שכמעט היתה לאגדה והתפרקה בנסיבות מסתוריות רגע לפני הפריצה קדימה. שנים רבות אחרי הקונצרט האחרון של הלהקה, שנגמר באסון, נסחפים חייהן של כמה דמויות למערבולת מסוכנת שאין ממנה מוצא. בעלה של גרייס לוסון נעלם.",
                            Price = 71,
                            Discount = 0,
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "תמונות נסתרות",
                            Author = "ג׳ייסון רקולאק",
                            Image = "https://images-evrit.yit.co.il/Images/Products/NewBO/Products/28769/temunot_Master.jpg",
                            Summary = "תעלומה על צעירה שנאבקת בעברהּ, ועל ילד קטן עם סודות מוזרים ומטרידים. אחרי שנה וחצי במוסד גמילה, בעקבות תקרית טראגית והתמכרות למשככי כאבים, מלורי קווין נכונה לצאת ולפגוש את העולם שבחוץ. היא מתקבלת לעבודה כאומנת בביתם של טד וקרוליין, זוג צעיר ואמיד מאוד, הורים לטדי בן החמש.",
                            Price = 57,
                            Discount = 0,
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "המפתח של שרה",
                            Author = "טטיאנה דה רוניי",
                            Image = "https://images-evrit.yit.co.il/Images/Products/newcovers/hamafteach_shel_sara_master.jpg",
                            Summary = "פריז, מאי 2002: לקראת מלוא שישים שנה לוול-ד'איב מתבקשת ג'וליה ג'רמונד, עיתונאית אמריקאית, לכתוב על היום השחור הזה בעברה של צרפת. ג'וליה, שנשואה לצרפתי ומתגוררת בפריז זה עשרים וחמש שנים, נדהמת לגלות כמה הכחשה אופפת את האירוע הזה. במהלך התחקיר שלה היא נתקלת בעקבותיו של סוד משפחתי ישן שמחבר אותה אל שרה, סוד בן שישים שנה שמאיים על נישואיה שלה.",
                            Price = 60,
                            Discount = 0,
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "המכתבים הנסתרים",
                            Author = "לורנה קוק",
                            Image = "https://images-evrit.yit.co.il/Images/Products/NewBO/Products/33231/michtavim_Master.jpg",
                            Summary = "ענני המלחמה שמרחפים מעל שמי אירופה מתקרבים אל האחוזה רחבת הידיים של משפחת קאר-לאיון. העלמה הצעירה קרודיליה מנסה להסיח את דעתה מהדאגות באמצעות טיפול בגני האחוזה. עבודת הגינון מרגיעה ומסקרנת אותה, וכך גם הגנן החדש, אייזק. בין השניים מתפתח סיפור אהבה. זו אהבה סוחפת, ממכרת וסוערת, אולי דווקא משום שהיא אסורה. אייזק וקרודיליה שומרים על הרומן בסוד גם אחרי שאייזק מגוייס לצבא ונשלח לחזית. משם, הוא כותב לה מכתבים שמבטיחים עתיד משותף ומאושר.",
                            Price = 101,
                            Discount = 0,
                        },
                        new BookModel
                        {
                            Id = Guid.NewGuid(),
                            BookName = "הבת מפריז",
                            Author = "קריסטין הרמל",
                            Image = "https://images-evrit.yit.co.il/Images/Products/NewBO/Products/31571/habat_meparis_Master.jpg",
                            Summary = @"פריז, 1939. האמהות הצעירות אליס וג'ולייט נעשות חברות טובות לאחר שהן נפגשות יום אחד ביער בולון היפהפה. אף אחת מהן לא יכולה לחזות אז את הצל שתטיל המלחמה על צרפת וכיצד היא תטלטל את חייהן.

                    כשחייה של אליס נתונים בסכנה בגלל הנאצים, היא מפקידה אצל ג'ולייט את הדבר היקר לה ביותר בעולם – בתה הפעוטה. אבל שום מקום אינו בטוח במלחמה, אפילו לא חנות ספרים קטנה ושקטה כמו החנות של ג'ולייט ומשפחתה. וכשפצצה נופלת בשכונה, החנות ועולמה של ג׳ולייט נחרבים.",
                            Price = 98,
                            Discount = 0,
                        },
                                            new BookModel
                                            {
                                                Id = Guid.NewGuid(),
                                                BookName = "בלובירד",
                                                Author = "ג'נבייב גרהאם",
                                                Image = "https://images-evrit.yit.co.il/Images/Products/NewBO/Products/30935/Bluebird_Master.jpg",
                                                Summary = @"יום אחד הוא פשוט מופיע במקום העבודה שלה. גבר יפה, מלוכלך ומאובק, מחזיק חבילה בידו. קייסי פותחת את הצרור כמעט בחוסר עניין, ונדהמת. כאוצרת במוזיאון, היא בקושי מצליחה להסתיר את התרגשותה. הגבר היפה הביא איתו אוצר: בקבוק ויסקי עתיק ונדיר, שמצא טמון בקיר הבית שהוא משפץ.

                    1918.
                    המלחמה הגדולה עדיין מתחוללת. אדל סוואר, אחות צעירה בבית חולים שדה בבלגיה, מטפלת בעדינות אין קץ בג'רי, החולה המיוחד שלה. משהו בו מרגש אותה. האם זאת העובדה שגילתה שאי אז, בקנדה הרחוקה, הם היו כמעט שכנים? לחרדתה, ג'רי הולך ונרפא ובעוד רגע ישוב לחזית. ואז? מה יהיה אז?",
                                                Price = 40,
                                                Discount = 0,
                                            },
                                            new BookModel
                                            {
                                                Id = Guid.NewGuid(),
                                                BookName = "המטופלת השקטה",
                                                Author = "אלכס מיכאלידס",
                                                Image = "https://images-evrit.yit.co.il/Images/Products/covers_2019/silent_master.jpg",
                                                Summary = @"החיים של אלישה ברנסון נראים מושלמים. היא ציירת מפורסמת שנשואה לצלם אופנה מבוקש ומתגוררת בבית מידות בעל חלונות גדולים שנשקפים אל פארק באחד האזורים הנחשקים ביותר בלונדון. ערב אחד חוזר בעלה מאוחר מהעבודה, ואלישה יורה בו חמש פעמים בפנים, ומאותו רגע לא מוציאה מילה מהפה.

                    סירובה לדבר, או להעניק הסבר כלשהו למעשה, הופך את הטרגדיה המשפחתית לדבר מה גדול בהרבה, לפרשה שמציתה את דמיונו של הציבור והופכת את אלישה לדמות ידועה לשמצה. מחירי הציורים שלה מרקיעים שחקים, והיא, ""המטופלת השקטה"", מוסתרת מעיני הציבור והצהובונים בבית חולים פסיכיאטרי בצפון לונדון.",
                                                Price = 45,
                                                Discount = 0,
                                            },
                                            new BookModel
                                            {
                                                Id = Guid.NewGuid(),
                                                BookName = "המתיקות שבשכחה",
                                                Author = "קריסטין הרמל",
                                                Image = "https://images-evrit.yit.co.il/Images/Products/ebooks2/the_sweetness_of_forgetting_master.jpg",
                                                Summary = @"מאפיית ""כוכב הצפון"" שבקייפ קוד עוברת מאם לבת במשפחת מֶק'קנה זה שלושה דורות. מאז שהיא זוכרת את עצמה, ריח הקינמון והחמאה ומלאכת הערבוב והאפייה סיפקו להופ מק'קנה־סמית מזור ועוגן, ייעוד ונחמה. אולם לאחר גירושיה, דומה שהקסם פג. הקשיים הכלכליים, תובענותה של בתה המרדנית והטיפול בסבתה האהובה חולת האלצהיימר מאיימים להכריע את הופ, ולראשונה בחייה היא תוהה אם תוכל להמשיך להחזיק במאפייה.

                    משהו חייב להשתנות, והשינוי מגיע מכיוון בלתי־צפוי: ברגע של צלילות, חושפת רוז, סבתה הדמנטית, סודות מעברה ושולחת אותה לפריז להתחקות אחר אותו עבר כשבאמתחתה רק רשימת שמות מסתורית. מסעה של הופ מוביל אותה דרך מסגד ובית כנסת אל סיפור שתחילתו בתקופת השואה, ואל אהבה הטומנת בחובה מסתורין רב. אם תאזור את האומץ להתמודד עם הסודות של משפחתה, עשויה הופ למצוא מחדש את האמון בעצמה ובדרך שבחרה.",
                                                Price = 87,
                                                Discount = 0,
                                            },
                                            new BookModel
                                            {
                                                Id = Guid.NewGuid(),
                                                BookName = "הדירה ברחוב אמלי",
                                                Author = "קריסטין הרמל",
                                                Image = "https://images-evrit.yit.co.il/Images/Products/covers_2019/new_room_master.jpg",
                                                Summary = @"כשרובי הנדרסון נישאה לצרפתי מרסל בנואה, היא הייתה בטוחה שמצאה את האושר. היא עוזבת את קליפורניה ועוברת להתגורר בעיר חלומותיה פריז, בדירה ברחוב אמלי המשקיפה אל מגדל אייפל. אבל חייה החדשים והמאושרים מקבלים תפנית מטרידה עם פרוץ מלחמת העולם השנייה וכיבוש פריז בידי הגרמנים.
                    בצל ענני המלחמה יוצרת רובי קשרים אמיצים עם שרלוט, בת השכנים היהודיה, ויחד הן נשבעות לעשות כל שביכולתן על מנת לעזור לכוחות הטוב לנצח את כוחות הרשע. בתוך כך הן מגלות שגם באחת התקופות הקשות והאפלות בהיסטוריה, מצליחים האור והאהבה לחדור מבעד לסדקי החשיכה ולאחות לבבות שבורים.",
                                                Price = 75,
                                                Discount = 0,
                                            },
                                            new BookModel
                                            {
                                                Id = Guid.NewGuid(),
                                                BookName = "הבציר האבוד",
                                                Author = "אן מא",
                                                Image = "https://images-evrit.yit.co.il/Images/Products/covers_2019_b/abazir_master.jpg",
                                                Summary = @"אישה חוזרת אל הכרם המשפחתי בבורגונדי וחושפת במפתיע יומן אבוד, בת-משפחה עלומה וסוד שהוסתר מאז מלחמת העולם השנייה.
                    קייט רוצה להצטרף לקבוצה המובחרת של מוסמכים ליין בעולם. לשם כך עליה לעבור את מבחן המאסטר ביין שאין קשה ממנו. חודשים ספורים לפני המבחן הגורלי היא נוסעת לבורגונדי לבלות את האביב באחוזה המשפחתית, שם תוכל להתמחות ביינות בורגונדי ולחדש את הקשר עם בן דודה ניקו ואשתו הת'ר, שמנהלים את הכרם והיקב. האדם האחד שקייט מקווה להתחמק ממנו הוא ז'אן-לוק, יינן צעיר ומוכשר ואהבתה הראשונה.",
                                                Price = 80,
                                                Discount = 0,
                                            },
                                            new BookModel
                                            {
                                                Id = Guid.NewGuid(),
                                                BookName = "ההבטחה האסורה",
                                                Author = "לורנה קוק",
                                                Image = "https://images-evrit.yit.co.il/Images/Products/NewBO/Products/25679/promise_Master.jpg",
                                                Summary = @"באירופה משתוללת מלחמת העולם השנייה, אבל בבית אינברמוריי הכל מתנהל על מי מנוחות. אלא שאז, בדיוק ביום הולדתה ה-21, דקות אחרי שהיא נמלטת מהמסיבה שלה עצמה, עומדת קונסטנס מול האגם הסמוך לביתה ולא מאמינה למראה עיניה. האם היא היחידה שראתה עכשיו מטוס צבאי מתרסק לתוך המים? האם תצליח להציל את הטייס? ומדוע מעשה שכזה ישנה את חייה לעד?",
                                                Price = 55,
                                                Discount = 0,
                                            },
                                            new BookModel
                                            {
                                                Id = Guid.NewGuid(),
                                                BookName = "הכפר האבוד",
                                                Author = "לורנה קוק",
                                                Image = "https://images-evrit.yit.co.il/Images/Products/covers_2020/lostvillage_master.jpg",
                                                Summary = @"כולם ידעו על הכפר האבוד. כולם הכירו את הסיפור. זה היה מאותם מקרים שאנשים מדברים עליהם שנים: לילה אחד, בעיצומה של מלחמת העולם השנייה, נאלצו תושבי הכפר הבריטי טיינהאם לעזוב את ביתם כשהם מותירים מאחור חיים שלמים – בתים מלאים ברהיטים, באוכל, בזיכרונות, בתמונות שמספרות מעט ומסתירות הרבה.",
                                                Price = 53,
                                                Discount = 0
                                            }
                        );

                    await dbContext.SaveChangesAsync();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public static async Task<IdentityResult> SeedUsers(IServiceProvider serviceProvider)
        {
            //var dbContext = serviceProvider.GetRequiredService<BookstoreContext>();
            //var userManager = serviceProvider.GetRequiredService<UserManager<UserModel>>();

            //if (!dbContext.Users.Any())
            //{
            //    UserModel user = new()
            //    {
            //        Fullname = "moshe moshe",
            //        UserName = "admin",
            //        Email = "admin@admin.com",
            //        IsAdmin = true
            //    };

            //    try
            //    {
            //        var result = await userManager.CreateAsync(user, "Password01!Admin");
            //        if (result.Succeeded)
            //        {
            //            Console.WriteLine("User created successfully.");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Failed to create user.");
            //            foreach (var error in result.Errors)
            //            {
            //                Console.WriteLine($"Error: {error.Description}");
            //            }
            //        }
            //        return result;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex);
            //    }

            //}
            //return null;
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BookstoreContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserModel>>();

                if (!dbContext.Users.Any())
                {
                    UserModel user = new()
                    {
                        Fullname = "moshe moshe",
                        UserName = "admin",
                        Email = "admin@admin.com",
                        IsAdmin = true
                    };

                    var result = await userManager.CreateAsync(user, "Password01!Admin");
                    if (result.Succeeded)
                    {
                        Console.WriteLine("User created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to create user.");
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($"Error: {error.Description}");
                        }
                    }
                    return result;
                }
                Console.WriteLine("Users already exist in the database.");
                return null;
            }
        }
    }
}
