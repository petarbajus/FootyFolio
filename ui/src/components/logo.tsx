import Image from "next/image";

export default function Logo() {
  return (
    <div className="flex items-center">
      <Image src="/logo.png" alt="logo" width={50} height={50} />
      <h1 className="text-2xl font-bold">FootyFolio</h1>
    </div>
  )
}