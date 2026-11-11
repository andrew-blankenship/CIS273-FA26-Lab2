using System.Runtime.InteropServices;

namespace PrayerScheduler;

public class PrayerScheduler
{

    
    public int NumDailyPrayers => DailyPrayers.Count;
    // TODO
    public int NumNonDailyPrayers => nonDailyPrayersQueue.Count;

    public List<Prayer> DailyPrayers { get; } = new();

    private Queue<Prayer> nonDailyPrayersQueue = new(); 
    public List<Prayer> NonDailyPrayers
    {
        get
        {
            return nonDailyPrayersQueue.ToList();
        }
    }

    public List<Prayer> AnsweredPrayers { get; } = new();

    public PrayerScheduler()
    {
        
    }
        

    // TODO
    public void AddPrayer(Prayer prayer)
    {
        foreach (Prayer p in DailyPrayers)
        {
            if (p.ID == prayer.ID)
            {
                throw new DuplicateIDException();
            }
        }
        foreach (Prayer p in AnsweredPrayers)
        {
            if (p.ID == prayer.ID)
            {
                throw new DuplicateIDException();
            }
        }
        var num = 0;
        for (int i=0; i < nonDailyPrayersQueue.Count; i++)
        {
            
            var nonDailyPrayer = nonDailyPrayersQueue.Dequeue();
            if (nonDailyPrayer.ID == prayer.ID)
            {
                num = 1;

            }
            
            nonDailyPrayersQueue.Enqueue(nonDailyPrayer);
            
            
        }
        if (num == 1)
            {
                throw new DuplicateIDException();
            }
        
        
        // if answered
        // add it to answered
        if (prayer.IsAnswered)
        {
            AnsweredPrayers.Add(prayer);
            return;
        }
        //if unanswered
        // if daily, add to dailys
        if (prayer.IsDaily)
        {
            DailyPrayers.Add(prayer);
            return;
        }
        // unanawered, non-daily prayer
        nonDailyPrayersQueue.Enqueue(prayer);
        
            


    }

    // TODO
    public void AnswerPrayer(int id)
    {
        var dailyprayer = DailyPrayers.Find( p => p.ID == id );
        if (dailyprayer is not null)
        {
            dailyprayer.IsAnswered = true;
            DailyPrayers.Remove(dailyprayer);
            AnsweredPrayers.Add(dailyprayer);
            return;
        }

        for (int i=0; i < nonDailyPrayersQueue.Count; i++)
        {
            var nonDailyPrayer = nonDailyPrayersQueue.Dequeue();
            if (nonDailyPrayer.ID == id)
            {
                nonDailyPrayer.IsAnswered = true;
                AnsweredPrayers.Add(nonDailyPrayer);

            }
            else
            {
                nonDailyPrayersQueue.Enqueue(nonDailyPrayer);
            }
        }

        
    
    }

    // TODO
    public List<Prayer> GetPrayers(int numPrayers)
    {
        List<Prayer> prayers = new List<Prayer>(DailyPrayers);

        foreach ( var p in prayers)
        {
            p.LastPrayed = DateTime.Now;
        }


        // if (prayers.Count > numPrayers)
        // {
        //     return prayers;
        // }

        int spotsRemaining = numPrayers - DailyPrayers.Count;

        if (spotsRemaining > nonDailyPrayersQueue.Count)
        {
            spotsRemaining = nonDailyPrayersQueue.Count;
        }

        


        while ( spotsRemaining > 0)
        {
            var nonDailyPrayer = nonDailyPrayersQueue.Dequeue();
            nonDailyPrayer.LastPrayed = DateTime.Now;
            prayers.Add(nonDailyPrayer);
            nonDailyPrayersQueue.Enqueue(nonDailyPrayer);
            spotsRemaining--;
        
        }
        


        // for (int i=0; i < numPrayers - DailyPrayers.Count; i++)
        // {
        //     prayers.Add(nonDailyPrayersQueue.Dequeue());
        // }


        return prayers;
    }

}


