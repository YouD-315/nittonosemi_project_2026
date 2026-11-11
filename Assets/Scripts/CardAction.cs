public class CardAction
{
    public Character User { get; }
    public Character Target { get; }
    public CardData CardData { get; }
    public CardObj CardObj { get; } // 画面上のカード（プレイヤー用。敵など内部データのみの場合はnull）

    public CardAction(Character user, Character target, CardData cardData, CardObj cardObj = null)
    {
        User = user;
        Target = target;
        CardData = cardData;
        CardObj = cardObj;
    }
}