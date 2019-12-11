using UnityEngine;
using UnityEngine.UI;

namespace Complete
{
    public class AgentHealth : MonoBehaviour
    {
        public float m_StartingHealth = 100f;               // variable de la vida de cada de cada tanque empieza   
        public Slider m_Slider;                             // la barra que lo respresenta
        public Image m_FillImage;                           // la imagen del slider
        public Color m_FullHealthColor = Color.green;       // color de mucha vida
        public Color m_ZeroHealthColor = Color.red;         // color de poca vida
        public GameObject m_ExplosionPrefab;                // Prefab de la explosion de un tanque.
        
        
        private AudioSource m_ExplosionAudio;               // el audio del tanque
        private ParticleSystem m_ExplosionParticles;        // particalas o efecto de las mismas
        private float m_CurrentHealth;                      // Vida restante
        private bool m_Dead;                                // si el tanque no tiene vida


        private void Awake ()
        {
            // instancia las particulas a la muerte del tanque(explosion)
            m_ExplosionParticles = Instantiate (m_ExplosionPrefab).GetComponent<ParticleSystem> ();

            // Audio de la explosion instanciada
            m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource> ();

            // despliega el prefab de la explosion
            m_ExplosionParticles.gameObject.SetActive (false);
        }


        private void OnEnable()
        {
            // Resetea la vida y detemina si esta muerto o no
            m_CurrentHealth = m_StartingHealth;
            m_Dead = false;

            // Actualiza la vida del tauqe en el slider
            SetHealthUI();
        }


        public void TakeDamage (float amount)
        {
            // Rreduce la vida por el daño recibido
            m_CurrentHealth -= amount;

            // Cmbia los elementos del Ui
            SetHealthUI ();

            // Si la vida es menos o es 0 llama al metodo OnDeath
            if (m_CurrentHealth <= 0f && !m_Dead)
            {
                OnDeath ();
            }
        }


        private void SetHealthUI ()
        {
            // actualiza la vida en el slider
            m_Slider.value = m_CurrentHealth;

            // interpreta que color debe estar dependiendo de la vida
            m_FillImage.color = Color.Lerp (m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
        }


        private void OnDeath ()
        {
            m_Dead = true;

            // Mueve el prefab de la explosion a la posicion del tanque
            m_ExplosionParticles.transform.position = transform.position;
            m_ExplosionParticles.gameObject.SetActive (true);

            // ejecutas las particulas de la explosion
            m_ExplosionParticles.Play ();

            // ejecuta el sonido de la explosion
            m_ExplosionAudio.Play();

            // Apaga el tanque o lo hace desaparecer
            gameObject.SetActive (false);
        }
    }
}
