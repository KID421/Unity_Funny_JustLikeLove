using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

namespace KID
{
    public class Player : MonoBehaviour
    {
        public Knight.Player player;
        public CanvasGroup final;

        public Text title;
        public string titleText = "當你很認真玩一款遊戲n過關後才發現是糞 Gamenn像極了愛情";

        private bool restart;

        private void Start()
        {
            final.transform.GetChild(1).gameObject.SetActive(false);
        }

        private void Update()
        {
            Dead();
            Restart();
        }

        private void Dead()
        {
            if (transform.position.y < -4.5f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        private void Restart()
        {
            if (Input.GetKeyDown(KeyCode.R) && restart) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name == "傳送門")
            {
                StartCoroutine(End());
            }
        }

        private IEnumerator End()
        {
            player.enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;

            while (final.alpha < 1)
            {
                final.alpha += 0.05f;
                yield return null;
            }

            yield return StartCoroutine(ShowText());

            yield return new WaitForSeconds(0.5f);

            final.transform.GetChild(1).gameObject.SetActive(true);
            restart = true;
        }

        private IEnumerator ShowText()
        {
            string t = "";
            for (int i = 0; i < titleText.Length; i++)
            {
                if (titleText[i] == 'n') t += "\n";
                else t += titleText[i];
                title.text = t;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}

