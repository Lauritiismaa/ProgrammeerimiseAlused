namespace ProgrammeerimiseAlused.OOP.Liidesed;

// Harjutus 3: INime pärib IDisposable liidese ning lisab Kirjelda().
// Selle liidese rakendaja peab kirjutama nii Kirjelda() kui ka Dispose().
public interface INime : IDisposable
{
    void Kirjelda();
}
