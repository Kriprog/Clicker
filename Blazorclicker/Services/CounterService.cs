namespace Blazorclicker;
using System.Timers;
using System;

public class CounterService
{
    private decimal count = 0;
    private int clickPower = 1;
    private decimal priceOfClick = 5;
    private decimal autoClickerPower = 0.1M;
    private decimal priceOfAutoClicker = 20;
    private System.Timers.Timer autoClickerTimer;

    public decimal Count => count;
    public int ClickPower => clickPower;
    public decimal AutoClickerPower => autoClickerPower;
    public decimal PriceOfClick => priceOfClick;
    public decimal PriceOfAutoClicker => priceOfAutoClicker;

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
    public void IncrementCount()
    {
        count = count + (1 * clickPower);
        NotifyStateChanged(); // Notify UI of state change
    }
    public bool BuyClickPower()
    {
        if (Count >= priceOfClick)
        {
            count -= priceOfClick;
            clickPower++;
            priceOfClick = Decimal.Round(priceOfClick * 1.50M, 2);
            NotifyStateChanged();
            return true;
        }
        return false;
     }

    public void StartAutoClicker()
    {
        autoClickerTimer = new System.Timers.Timer(100);
        autoClickerTimer.Elapsed += OnAutoClickerEvent;
        autoClickerTimer.AutoReset = true;
        autoClickerTimer.Enabled = true;

    }
    private void OnAutoClickerEvent(object sender, System.Timers.ElapsedEventArgs e)
    {
        count += autoClickerPower;
        NotifyStateChanged();
    }
    public bool BuyAutoClickerPower()
    {
        if (Count >= priceOfAutoClicker)
        {
            count -= priceOfAutoClicker;
            autoClickerPower+= autoClickerPower+0.1M;
            priceOfAutoClicker = Decimal.Round(priceOfAutoClicker * 1.50M, 2);
            if (autoClickerTimer == null)
            {
                StartAutoClicker();
            }
            NotifyStateChanged();
            return true;
        }
        return false;

    }



}
