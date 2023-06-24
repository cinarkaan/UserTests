using NUnit.Framework;
using System.Runtime.InteropServices;

// Bunun gibi SDK stili projelerde, geçmişte bu dosya içinde tanımlanan birkaç bütünleştirilmiş
// kod özniteliği, artık derleme sırasında otomatik olarak eklenir ve proje özelliklerinde
// tanımlanan değerlerle doldurulur. Hangi özniteliklerin dahil edileceği ve bu işlemin
// nasıl özelleştirileceği hakkında ayrıntılı bilgi için bkz. https://aka.ms/assembly-info-properties


// ComVisible değerinin false olarak ayarlanması, bu bütünleştirilmiş koddaki türleri
// COM bileşenlerine görünmez hale getirir. Bu bütünleştirilmiş koddaki bir türe COM'dan
// erişmeniz gerekiyorsa, ComVisible özniteliğini bu türde true olarak ayarlayın.

[assembly: ComVisible(false)]

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(5)]
// Aşağıdaki GUID, bu projenin COM'un kullanımına sunulması durumunda typelib'in kimliği
// içindir.

[assembly: Guid("d62f2146-b912-4f93-b173-8f254623b51a")]
