static void Q2TavlatMaakav() // לנוחותכם הקוד ששימש לטבלת המעקב 
{ 
  int[] arr = new int[6]; int i, k; int num;
  i = 0;
  k = arr.Length - 1;
  while (i <= k)
  {
    num = int.Parse(Console.ReadLine());
    if (num % 2 == 0)
    {
      arr[i] = num;
      i++;
    }
    else
    {
      arr[k] = num;
      k--;
    }
  }
  Console.WriteLine("i = " + i + " k = " + k);
}

//==== פתרון מבחן 15.12 ====
//===========================
#region שאלה 1
// Q1 =======================
static void Fill(int[] arr, in int num)
{
  for (int i = 0; i < arr.Length; i++)
    arr[i] = (i + 1) * ((i + 1) % 2); // זוגיים יעבדו ואי זוגיים יאופסו
  if (arr[^1] != 0) // [^1] same as arr[arr.Length - 1]
    arr[^1] = num;
}
static void Fill2(int[] arr, in int num)
{ // Q1 אפשרות נוספת
  for (int i = 0; i < arr.Length-1; i += 2)
  {
    arr[i] = i + 1;
    arr[i + 1] = 0;
  }
  if (arr.Length % 2 != 0)
    arr[^1] = num;
}
// קוד הדגמה - אין צורך / אסור לרשום את החלק הזה 
// בבחינה אם לא ביקשו
int[] nums = new int[11];
Fill(nums, 993);
foreach (var n in nums)
  Console.WriteLine(n);
#endregion
#region שאלה 2
//i==4 שאלה 2 ב' קלט שיוביל ל
//1,1,2,2,2,2
// ב-1 i כל קלט זוגי מגדיל את
// k צריך גם 2 קלטים אי זוגיים כדי לקדם את  
// שכן עד שלא יהיו 6 קלטים הלולאה לא תסתיים
// בהתאם לסעיף ג יש צורך בקלט כגון 1,1,1,1,1,1
// כל 6 מספרים אי זוגיים יקטינו את 
// עד למינוס 1 והלולאה תסתיים k 

// ד
// מטרת הקוד היא למלא את המערך
// בפרט הזוגיים בחלקו השמאלי והאי זוגיים בחלקו הימני
// התכנית מסתיימת כשהתקבלו מספר קלטים כאורך המארך
// במקום היה מערך של 8 והקטננו ל-6 כדי להקל על המעקב
// אינו מטרת התכנית i,k הפלט של 
// המונים האלו הם רק כלי להשגת המטרה
#endregion
#region שאלה 3
// Q3)1) =================================
static void DigLocPrint(int num, int digit)
{
  int i = 0; bool found = false;
  Console.WriteLine($"Digits {digit}:");
  while (num > 0)
  {
    i++; // הגדלת מונה
    if (num % 10 == digit) // בדיקת התאמה
    {
      Console.Write($"{i},");
      found = true;
    }
    num /= 10; // אלגוריתם פירוק מספר לספרות
  }
  if (!found) // מקרה קצה
    Console.Write("-1");
  Console.WriteLine(); //מעבר שורה
}
static void MainQ32()
{
  Random rnd = new Random();
  int num = rnd.Next(1000, 10000);
  Console.WriteLine("the num:" + num);
  int k = 1;
  for (int i = 0; i < 10; i++)
    DigLocPrint(num, i);
}
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("\nSolution for question 3:");
MainQ32();
// Q3 alternative by one student
// בעיקרון אין רשות להחזיר מערך אם הוגדר שהפונקציה תדפיס
// מוצג בכל זאת פתרון טוב במערך שכתב תלמיד 
static int[] Q31DigLocPrintByStd(int num, int digit)
{
  int k = 1, times = 0;
  while (k <= num)
  {
    k = k * 10;
    times++;
  }
  int[] numbers = new int[times];
  k = 1;
  for (int i = 0; i < times; i++)
  {
    numbers[i] = (num / k) % 10;//take the i digit;
    k = k * 10;
  }
  times = 0;
  foreach (int v in numbers)
    if (v == digit)
      times++;
  if (times == 0)
  {
    int[] none = { -1 };
    return none;
  }
  int[] res = new int[times];
  k = 0;
  for (int i = 0; i < numbers.Length; i++)
    if (numbers[i] == digit)
    {
      res[k] = i + 1;
      k++;
    }
  return res;
}
static void MainQ31DigLocPrintByStd()
{
  Random rnd = new Random();
  int num = rnd.Next(1000, 10000);
  Console.WriteLine("the num:" + num);
  int k = 1;
  for (int i = 0; i < 10; i++)
  {
    Console.WriteLine($"\nDigit {i}:");
    int[] digs = Q31DigLocPrintByStd(num, i);
    foreach (int dig in digs)
      Console.Write(dig + ", ");
  }
}
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\nSolution by student, for question 3:");
MainQ31DigLocPrintByStd();
#endregion
#region שאלה 4
// Q4 ==============================================
static int Reverse(int num)
{
  int res = 0;
  while (num > 0)
  {
    res = res * 10 + num % 10; //add digit and push to the left
    num /= 10;
  }
  return res;
}
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\n\nSolution for Q4:");
Console.WriteLine(Reverse(1200));
#endregion
#region שאלה 5
// Q5 ==============================================
static void ZigZag(int[] arr)
{
  int sign = 1;
  for (int i = 0; i < arr.Length; i++)
  { // ניתן לפתור בעוד די הרבה דרכים
    arr[i] = Math.Max(1, Math.Abs(arr[i]));
    arr[i] *= sign;
    sign *= -1; // toggle the sign from 1 to -1 to 1 to -1
  }
}

static void MainQ5()
{
  Random rnd = new Random();
  int num;
  int[] nums = new int[20];
  for (int i = 0; i < nums.Length; i++) // fill the array
  {
    //nums[i] = rnd.Next(-100, 101); // ללא בונוס
    while (true) //  אופצית בונוס מגרילה בתוך לולאה
    {  // ( ודואגת להסיר את האפסים (לנסות שוב אם יוצא 0
      nums[i] = rnd.Next(-100, 101);
      if (nums[i] != 0) // אופצית בונוס
        break;
    }
  }
  ZigZag(nums); // טיפול במערך
  foreach (int n in nums) // הדפסת המערך
    Console.Write(n + ", ");
}
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n\nSolution for Q5:");
MainQ5();
#endregion