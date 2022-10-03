using UnityEngine;
/// <summary>
/// Cкрипт создает окружение на поле
/// </summary>
public class CreateLevel : MonoBehaviour
{
    [SerializeField]
    private Transform field;
    [SerializeField]
    private Thorns thorns;
    [SerializeField]
    private Money money;

    [SerializeField]
    private int countMoney;
    [SerializeField]
    private int countThorns;

    private const float BORDERS = 1f;

    private void Awake()
    {
        int countXPos = (int)((field.localScale.x - 2 * BORDERS) / (money.transform.localScale.x));
        int countZPos = (int)((field.localScale.z - 2 * BORDERS) / (money.transform.localScale.z));
        bool[,] isOccupied = new bool [countXPos, countZPos];
        for (int i = 0; i < countMoney; i++)
        {
            int xPos;
            int zPos;
            do
            {
                xPos = Random.Range(0, countXPos);
                zPos = Random.Range(0, countZPos);
            }
            while (isOccupied[xPos, zPos]);

            isOccupied[xPos, zPos] = true;
            Instantiate(money, field.position + new Vector3(field.localScale.x / 2 - BORDERS - xPos * money.transform.localScale.x, money.transform.localScale.y, field.localScale.z / 2 - BORDERS - zPos * money.transform.localScale.z), Quaternion.identity);
        }

        for (int i = 0; i < countThorns; i++)
        {
            int xPos;
            int zPos;
            do
            {
                xPos = Random.Range(0, countXPos);
                zPos = Random.Range(0, countZPos);
            }
            while (isOccupied[xPos, zPos]);

            isOccupied[xPos, zPos] = true;

            Instantiate(thorns, field.position + new Vector3(field.localScale.x / 2 - BORDERS - xPos * thorns.transform.localScale.x, thorns.transform.localScale.y, field.localScale.z / 2 - BORDERS - zPos * thorns.transform.localScale.z), Quaternion.identity);
        }
    }
    /// <summary>
    /// Возвращает количество монет на поле
    /// </summary>
    /// <returns></returns>
    public int GetCountMoney()
    {
        return countMoney;
    }
}
