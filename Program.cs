using System.Diagnostics;

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
  for (int i = 0; i < arr.Length - 1; i += 2)
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

// פתרונות לשאלות ממטלות
#region מטלה 20
#region שאלת הפרמוטציות
// יש ליצור ולהדפיס את כל המילים שניתן להרכיב מ-3 אותיות '.
// from n first letters of the abc...
// a brute force solution (קיימים אלגוריתמים רקורסיביים ליצירה דטרמיניסטית)
static void Main7()
{
  Random rnd = new Random();
  Console.WriteLine("\n finding permutations radnomly:");
  PrintAllWords(3);
  Console.WriteLine();
  Console.ForegroundColor = ConsoleColor.Blue;
  PrintAllWords(4);
  Console.WriteLine();
  Console.ForegroundColor = ConsoleColor.Green;
  PrintAllWords(5);
  Console.WriteLine();
  // here using internal functions (לא בחומר).
  // Otherwise it's difficult (or impossible) to have one instance of rnd
  // throughout all the randomizations...
  // in a normal console or other app this would not become a problem.
  // internal functions are לא בחומר
  // an alternative presentation would be to take these functions out, 
  // but remove the static MODIFIER from Main7 and from all these functions.
  int Factorial(int n)
  {
    int res = 1;
    for (int i = 2; i <= n; i++)
      res *= i;
    return res;
  }
  string[] GetAllWords(int n)
  {
    //במחשבה שנייה עדיף לפצל אגם לפונקציה שמחזירה מערך ובו כל המילים
    int fact = Factorial(n);
    string[] words = new string[fact];
    for (int i = 0; i < fact; i++)
    {
      words[i] = RandomPermutation(n);
      for (int j = 0; j < i; j++)
        if (words[j] == words[i])
        {
          i--;
          break;
        }
    }
    return words;
  }
  void PrintAllWords(int n)
  {
    // משאיר לפונקציה המדפיסה רק את ההדפסה
    // ובדיקת התקינות של הערכים שהוחזרו
    // הפיצול לפונקציות שעושות חלקים קטנים מקל על הדיבוג 
    string[] words = GetAllWords(n);
    foreach (var item in words)
      Console.WriteLine(item);
    // בדיקת תקינות - האם יש כפילויות במערך
    // לא מיועד לשימוש בבגרות 
    // comparer למי שישתמשו בעצמים - יש צורך להוסיף 
    // וזה לגמרי לא בחומר
    Debug.Assert(words.Distinct().Count() == words.Length);
  }

  string RandomPermutation(int n)
  {
    char k = 'a';
    char[] arrTemp = new char[n];
    int len = arrTemp.Length;
    for (int i = 0; i < len; i++)
    {
      int pos = rnd.Next(len); //choose position, decrease j.
      while (arrTemp[pos] != '\0')
        pos = (pos + 1) % len;  // round robin the position.
                                // assures we will not get index out of range.
      arrTemp[pos] = k++; //place the letter, and prepare for the next letter.
    }
    return new string(arrTemp);//.ToString() will not work!!!
                               //not sure this version is fully random on long strings.
  }
}

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n\nSolution for premutations from Matala20 Q4");
Main7();
#endregion
#region שאלת ניתוח המחרוזות
Console.ForegroundColor = ConsoleColor.Red;
string[] tetKids = { "Ziv Geller", "Tahel Tal",
  "Guy Siedes", "בתאל ש", "גיא פנקינסקי"};

int[] res = AnalyzeNames(tetKids);
Console.WriteLine($"\n\nSolution for Matala 20 Q1:\n אל appears in {res[0]} names");
Console.WriteLine($"we have {res[1]} long names");
Console.WriteLine($"we have {res[2]} student(s) with identical first and last letters");

static int[] AnalyzeNames(string[] tetKids)
{
  int[] counters = new int[3];//להכניס את התוצאות
  foreach (string name in tetKids)
  {
    //part 1:
    if (name.Contains("אל"))
      counters[0]++;
    //part 2:
    if (name.Length > 8)
      counters[1]++;
    //part 3:
    int indSpace = name.IndexOf(' ');
    if (name[0] == name[indSpace + 1])
      counters[2]++;
  }
  return counters;
}
#endregion
#endregion

#region NCountOdd, CountZeros questions, מטלה 21 החדרת ספרה למספר
static int NCountOdd(int n, int[] arr)
{
  int count = 0;
  foreach (var item in arr) // ריצה פשוטה על המערך
    if (NCountOdd1(n, item)) // ספירה במידת הצורך
      count++;
  return count;
}

static bool NCountOdd1(int n, int num)
{ //returns true if the digit d has odd occurences מופיעה מספר אי זוגי של פעמים
  //called by NCountOdd.
  if (n == num) // zero handling...
    return true;
  int count = 0;
  while (num > 0)
  {
    if (num % 10 == n)
      count++;
    num /= 10;
  }
  return count % 2 == 1; // מחזיר את אי זוגיות התוצאה: כן/לא
}

static int CountZeros(long[] arr)
{ // יש לספור איברים המכילים 0 או דו ספרתיים
  int count = 0;
  foreach (var item in arr)
    if (item < 100 && item > 9 || Has0(item)) count++;
  return count;
}
static bool Has0(long n)
{ // הפונקציה יודעת לזהות ספרה 0 במספר
  if (n == 0)
    return true;
  while (n > 0) //אלגוריתם פירוק מספר
  {
    if (n % 10 == 0) return true;
    n /= 10;
  }
  return false;
}
static int Insert(int pos, int digit, int num)
{
  int divider = (int)Math.Pow(10, pos);
  int right = num % divider;
  int left = num / divider;
  int res = digit * divider + left * divider * 10 + right;
  return res;
}
static void MainMatala21()
{
  // CountZeros בדיקת 
  Debug.Assert(CountZeros(new long[] { 1, 2, 3 }) == 0, "for { 1, 2, 3 } should return 0");
  Debug.Assert(CountZeros(new long[] { 0 }) == 1, "not handling 0");
  Debug.Assert(CountZeros(new long[] { 20, 300, 0 }) == 3, "possible double count");
  Debug.Assert(CountZeros(new long[] { 20, 305555, 0 }) == 3, "possible double count");
  Debug.Assert(CountZeros(new long[] { 9218, 77, 0 }) == 2, "mishandling 2 digits");
  Debug.Assert(CountZeros(new long[] { 20, 77, 0 }) == 3, "possible double count");
  long[] a = { 20, 77, 0 };
  CountZeros(a);
  Debug.Assert(a[0] == 20, "your code changed items in the array");
  Console.WriteLine("All assertions for CoutZeroes are successful\n");

  // NCountOdd בדיקת 
  Debug.Assert(NCountOdd(3, new int[] { 33030, 3, 33 }) == 2, "3,{ 33030,3,33} should return 2");
  Debug.Assert(NCountOdd(4, new int[] { 34030, 4, 4404 }) == 3, "3,{ 33030,3,33} should return 3");
  Debug.Assert(NCountOdd(0, new int[] { 33030, 0, 33 }) == 1, "3,{ 33030,3,33} should return 2");
  Console.ForegroundColor = ConsoleColor.Green;
  Console.WriteLine("\nAll assertions for NCountOdd are successfull\n");

  // Insert בדיקת שאלת החדרת ספרה למספר 
  Debug.Assert(Insert(0, 8, 5533) == 55338);
  Debug.Assert(Insert(1, 7, 5533) == 55373);
  Debug.Assert(Insert(3, 8, 199999) == 1998999);
  Debug.Assert(Insert(6, 8, 199999) == 8199999);
  Debug.Assert(Insert(7, 8, 199999) == 80199999); //טיפה שונה…
  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.WriteLine("\nAll assertions for Insert are successfull\n");
}
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("\n\nSolution for Some Matala 21 questions:");
MainMatala21();
#endregion
#region מטלה 22 בדיקת שכיחות הטלות קוביה,
static long[] ThrowDice(long n)
{
  // נניח לצורך הפתרון ש-0 מייצג 6 בקוביה
  // וכל מספר אחר מייצג את עצמו 
  // ניתן לחילופין להגדיר ייצוג אחר
  // או להגדיר מערך בגדול 7
  long[] frequencies = new long[6];
  Random rnd = new Random();
  for (int i = 0; i < n; i++)
    frequencies[rnd.Next(6)]++;
  return frequencies;
}
static void MainMatala22()
{
  long[] res = ThrowDice(100000);
  double ratio = res.Min() / (double)res.Max(); // critical to add 0.0 before the division
  // or cast to (double) before the division. Otherwise your ratio will be 1, 
  // regardless of the accuracy of your random function.
  Console.WriteLine("\nFrequency ratio between min to max dice results\n" + ratio);
  if (ratio < 0.95)
    Console.WriteLine("Something is probably wrong with your randomization");
}

Console.ForegroundColor = ConsoleColor.Red;
MainMatala22();

#endregion

#region ( ניתוח סדרה עולה ( לא במטלות:
// שאלת הסדרה העולה. לא נמצאת במטלות.
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\nSequence Analysis:\n" + IsRising(new int[] { 1, 3, 5 }));
Console.WriteLine(IsRising(new int[] { 3, 3, 3 }));
Console.WriteLine(IsRising(new int[] { 5, 3, 1 }));
Console.WriteLine(IsRising(new int[] { 5, 3, 3 }));
Console.WriteLine(IsRising(new int[] { 1, 3, 3 }));
Console.WriteLine(IsRising(new int[] { 1, 3, 1 }));
static string IsRising(int[] nums)
{
  bool IsRising = true;
  bool IsDescending = true;
  bool IsRisingWeak = true;
  bool IsDescendingWeak = true;
  for (int i = 0; i < nums.Length - 1; i++)
  {
    if (nums[i] > nums[i + 1])
    {
      IsRising = false;
      IsRisingWeak = false;
    }
    else if (nums[i] < nums[i + 1])
    {
      IsDescending = false;
      IsDescendingWeak = false;
    }
    else //are equal
    {
      IsDescending = false;
      IsRising = false;
    }
  }
  if (IsRising)
    return "IsRising";
  else if (IsDescending)
    return "IsDescending";
  else if (IsRisingWeak && IsDescendingWeak)
    return "Constant";
  else if (IsRisingWeak)
    return "IsRisingWeak";
  else if (IsDescendingWeak)
    return "IsDescendingWeak";
  else return "None";
}

#endregion

Console.ForegroundColor = ConsoleColor.White;