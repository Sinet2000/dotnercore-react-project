type Props = {
  children: React.ReactNode;
  className?: string;
};

export const SecondaryText = ({
  className = "secondary-text",
  children,
}: Props) => {
  const style = {
    color: "#a6a6a6",
    fontSize: "12px",
    fontWeight: 600,
  };

  return (
    <p style={style} className={className}>
      {children}
    </p>
  );
};
